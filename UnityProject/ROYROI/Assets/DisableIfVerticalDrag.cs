using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DisableIfVerticalDrag : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log(eventData.delta);
        //if y > x by 1 , turn off

        if (Mathf.Abs(eventData.delta.y) > Mathf.Abs(eventData.delta.x) + 1) {
            //Turn off
            //And set active to a vertical?
        }

    }
}
