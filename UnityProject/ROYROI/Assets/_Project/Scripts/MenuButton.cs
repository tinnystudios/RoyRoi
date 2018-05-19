using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, IPointerClickHandler {
    public SideBar sideBar;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clicked)");
        sideBar.Enter();
    }
}
