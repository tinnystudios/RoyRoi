using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[ExecuteInEditMode]
public class SideBar : StateBase, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public GameObject m_Blocker;
    
    public RectTransform m_Content;
    [Range(0,1)]public float value = 1;
    public float sensitivity = 0.5F;
    public float dir = 1;
    public float snapDuration = 0.1F;
    public AnimationCurve snapCurve;
    public Vector3 lastPos;

    public bool isEnter;
    public bool isUserUsing;

    public List<PageButton> m_PageButtons;
    #region Drag

    void Awake() {

        GetComponentsInChildren(includeInactive: true, result: m_PageButtons);

        foreach (var button in m_PageButtons)
        {
            button.m_OnClick += Exit;
        }

        ResetChildren();

        TouchInput.OnTouchUp += OnTouchUp;
    }

    void OnDestroy()
    {
        foreach (var button in m_PageButtons)
        {
            button.m_OnClick -= Exit;
        }
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            ProcessDrag();
            return;
        }

        if (!TouchInput.isMovingHorizontally)
        {
            isUserUsing = false;
        }

        ReadStateAndApplyValue();
        ProcessDrag();
        //ReadInputAndApplyState();

        if (Input.GetMouseButtonUp(0)) {
            isEnter = false;
        }

    }

    private void ReadStateAndApplyValue()
    {
        if (CanApply())
        {
            ApplyValue();
            isUserUsing = true;
        }
    }
    public bool CanApply()
    {
        return isEnter && TouchInput.isPressed || isUserUsing;
    }
    public void ReadInputAndApplyState()
    {

        if (Input.GetMouseButtonUp(0))
        {
            if (value > 0.5F)
            {
                value = 1;
                SetPositionFromValue(value);
                m_Blocker.SetActive(true);
            }
            else
            {
                value = 0;
                SetPositionFromValue(value);
                m_Blocker.SetActive(false);
            }

            isUserUsing = false;
        }

    }

    public bool isSetting = false;

    public Coroutine SetPositionFromValue(float v)
    {
        if (ValueToAnchorPosition(value) == m_Content.anchoredPosition)
            return null;

        if (isSetting)
            return null;

        var x = Mathf.Lerp(m_Content.sizeDelta.x,0,v);
        return StartCoroutine(SetPosition(new Vector2(x, 0), snapDuration));
    }

    IEnumerator SetPosition(Vector2 position, float length)
    {
        isSetting = true;
        var a = m_Content.anchoredPosition;
        for (float i = 0; i <= 1.0F; i += Time.deltaTime / length)
        {
            m_Content.anchoredPosition = Vector2.Lerp(a, position, snapCurve.Evaluate(i));
            yield return null;
        }

        m_Content.anchoredPosition = Vector2.Lerp(a, position, 1.0F);
        ApplyValue();
        isSetting = false;
    }

    public void ApplyValue()
    {
        value = m_Content.anchoredPosition.x / m_Content.sizeDelta.x;
        value = Mathf.Lerp(1, 0, value);
        value = Mathf.Clamp01(value);
    }

    public float AnchorPositionToValue(Vector2 position)
    {
        var v = m_Content.anchoredPosition.x / m_Content.sizeDelta.x;
        v = Mathf.Lerp(1, 0, v);
        v = Mathf.Clamp01(value);
        return v;
    }

    public Vector2 ValueToAnchorPosition(float value)
    {
        var x = Mathf.Lerp(m_Content.sizeDelta.x, 0, value);
        return new Vector2(x, 0);
    }

    public void ProcessDrag()
    {
        if (!CanApply())
            return;

        if (!TouchInput.isMovingHorizontally)
            return;

        var computePosition = m_Content.anchoredPosition;

        var minPos = computePosition;
        var maxPos = computePosition;

        minPos.x = m_Content.sizeDelta.x;
        maxPos.x = 0;

        //size delta 

        m_Content.position += new Vector3(TouchInput.delta.x, 0,0);

        if (m_Content.anchoredPosition.x > minPos.x)
            m_Content.anchoredPosition = Vector3.Lerp(minPos, maxPos, 0);

        if (m_Content.anchoredPosition.x < maxPos.x)
            m_Content.anchoredPosition = Vector3.Lerp(minPos, maxPos, 1);
    }

    public bool IsSideBarTab(GameObject go)
    {
        return go.GetComponent<ISideBarChildren>() != null;
    }

    public void OnTouchUp() {

        if (m_Blocker.activeInHierarchy && !TouchInput.isMovingHorizontally)
        {
            var currentSelectedObject = EventSystem.current.currentSelectedGameObject;

            if (currentSelectedObject == null)
                return;

            if (currentSelectedObject != gameObject && !IsSideBarTab(currentSelectedObject))
            {
                Exit();
                Debug.Log("Exit");
            }
        }

        //Making sure the blocker is on.
        if (value >= 0.5F)
        {
            value = 1;
            m_Blocker.SetActive(true);
            SetPositionFromValue(1);
        }
        else
        {
            value = 0;
            m_Blocker.SetActive(false);
            SetPositionFromValue(0);
        }

        isUserUsing = false;

    }

    public void CheckBlocker()
    {

        //Making sure the blocker is on.
        if (value >= 1)
        {
            m_Blocker.SetActive(true);
        }
        else
        {
            m_Blocker.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(value != 0)
         isEnter = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isEnter = false;
    }

    #endregion

    //State
    public override IEnumerator OnTransitionIn()
    {
        value = 1;
        SetPositionFromValue(value);
        ResetChildren();
        yield break;
    }

    public override IEnumerator OnTransitionOut()
    {
        ResetChildren();
        value = 0;
        yield return SetPositionFromValue(value);
        m_Blocker.SetActive(false);
    }

    public void ResetChildren()
    {
        var children = GetComponentsInChildren<ISideBarChildren>();

        foreach (var s in children)
        {
            s.OnReset();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isEnter = true;
    }
}
