using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[ExecuteInEditMode]
public class SideBar : StateBase, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject m_Blocker;

    public Vector2 m_Delta;
    public RectTransform m_Content;
    [Range(0,1)]public float value = 1;
    public float sensitivity = 0.5F;
    public float dir = 1;

    public Vector3 lastPos;

    public bool isPressed;
    public bool isEnter;
    public bool isUserUsing;

    #region Drag

    void Update()
    {
        if (!Application.isPlaying)
        {
            ApplyPosition();
            return;
        }

        ReadInputAndApplyState();
        ReadStateAndApplyValue();
        ReadInputDelta();
        ApplyPosition();
        ApplyBlockerLogic();
    }

    private void ReadStateAndApplyValue()
    {
        if (isEnter && isPressed || isUserUsing)
        {
            ApplyValue();
            isUserUsing = true;
        }
    }

    public void ReadInputAndApplyState()
    {
        if (Input.GetMouseButton(0))
        {
            isPressed = true;
        }
        else
            isPressed = false;

        if (Input.GetMouseButtonUp(0))
        {
            if (value > 0.3F)
                value = 1;

            if (value < 0.7F)
                value = 0;

            isUserUsing = false;
        }

    }

    public void ApplyValue()
    {
        value += m_Delta.x * sensitivity * Time.deltaTime * dir;
        value = Mathf.Clamp01(value);
    }

    public void ApplyPosition()
    {
        var computePosition = m_Content.anchoredPosition;

        var minPos = computePosition;
        var maxPos = computePosition;

        minPos.x = m_Content.sizeDelta.x;
        maxPos.x = 0;

        m_Content.anchoredPosition = Vector3.Lerp(minPos, maxPos, value);
    }

    public void ReadInputDelta()
    {
        var currentPosition = Input.mousePosition;
        m_Delta = currentPosition - lastPos;
        lastPos = currentPosition;
    }

    public void ApplyBlockerLogic()
    {
        if (m_Blocker.activeInHierarchy)
        {
            var currentSelectedObject = EventSystem.current.currentSelectedGameObject;

            if (currentSelectedObject == null)
                return;

            if (Input.GetMouseButtonUp(0))
            {
                if (currentSelectedObject != gameObject)
                    Exit();
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (value != 1 && value != 0)
            {
                m_Blocker.SetActive(false);
            }
        }

        //
        if (Input.GetMouseButtonUp(0))
        {
            if (value >= 1)
            {
                //On
                m_Blocker.SetActive(true);
            }
            else
            {
                //Off
                m_Blocker.SetActive(false);
            }
        }

    }

 

    public void OnPointerEnter(PointerEventData eventData)
    {
        lastPos = Input.mousePosition;
        m_Delta = Vector3.zero;
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
        m_Blocker.SetActive(true);
        value = 1;
        yield break;
    }

    public override IEnumerator OnTransitionOut()
    {
        value = 0; 
        yield break;
    }

}
