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
            ApplyPosition();
            return;
        }

        if (!TouchInput.isMovingHorizontally)
        {
            isUserUsing = false;
        }

        ReadStateAndApplyValue();
        ApplyPosition();
        ApplyBlockerLogic();
        ReadInputAndApplyState();

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

    public void SetPositionFromValue(float v)
    {
        var x = Mathf.Lerp(m_Content.sizeDelta.x,0,v);
        m_Content.anchoredPosition = new Vector2(x, 0);
    }

    public void ApplyValue()
    {
        value = m_Content.anchoredPosition.x / m_Content.sizeDelta.x;
        value = Mathf.Lerp(1, 0, value);
        value = Mathf.Clamp01(value);
    }

    public void ApplyPosition()
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


    public void ApplyBlockerLogic()
    {
        if (TouchInput.isMovingHorizontally)
            return;

        //If blocker is active, And you released on a button, turn off
        if (m_Blocker.activeInHierarchy)
        {

            var currentSelectedObject = EventSystem.current.currentSelectedGameObject;

            if (currentSelectedObject == null)
                return;

            if (Input.GetMouseButtonUp(0))
            {
                if (currentSelectedObject != gameObject && !IsSideBarTab(currentSelectedObject))
                {
                    Exit();
                } 
            }
        }

        //if pressing down and you're not full, turn off the blocker.
        if (Input.GetMouseButton(0))
        {
            if (value != 1 && value != 0)
            {
                m_Blocker.SetActive(false);
            }
        }

        //If release, check value
        if (Input.GetMouseButtonUp(0))
        {
            //Invisible
            if (value >= 1)
            {
                m_Blocker.SetActive(true);
                SetPositionFromValue(1);
            }
            else
            {
                m_Blocker.SetActive(false);
                SetPositionFromValue(0);
            }

            isUserUsing = false;
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
        value = 0;
        SetPositionFromValue(value);
        ResetChildren();
        m_Blocker.SetActive(false);
        yield break;
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
