using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PageButton : MonoBehaviour, IPointerClickHandler {
    public PageState page;

    public void OnPointerClick(PointerEventData eventData)
    {
        page.Enter();
    }
}
