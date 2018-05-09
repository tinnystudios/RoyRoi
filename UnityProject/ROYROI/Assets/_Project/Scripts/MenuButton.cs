using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, IPointerClickHandler {
    public PopUpList popUpList;

    public void OnPointerClick(PointerEventData eventData)
    {
        popUpList.Toggle();
    }
}
