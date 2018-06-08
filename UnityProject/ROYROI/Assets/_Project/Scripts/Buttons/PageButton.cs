using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PageButton : MonoBehaviour, IPointerClickHandler {
    public Action m_OnClick;
    public PageState page;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(m_OnClick != null)
            m_OnClick.Invoke();

        page.Enter();
    }
}
