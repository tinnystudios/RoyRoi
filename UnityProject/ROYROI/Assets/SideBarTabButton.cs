using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SideBarTabButton : MonoBehaviour, IPointerClickHandler, ISideBarChildren
{
    public GameObject m_TabContent;

    public void OnPointerClick(PointerEventData eventData)
    {
        m_TabContent.SetActive(!m_TabContent.activeInHierarchy);
    }

    public void OnReset()
    {
        m_TabContent.SetActive(false);
    }
}

public interface ISideBarChildren
{
    void OnReset();
}