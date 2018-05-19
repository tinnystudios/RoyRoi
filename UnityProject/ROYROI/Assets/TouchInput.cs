using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//#TODO Create the touch input module currently SideBar is generatin delta & pressed which should belong to touchInput
public class TouchInput : MonoBehaviour {

    public static Vector2 delta;
    public static bool isPressed;

    public static Action OnTouch;
    public static Action OnTouchUp;

    private Vector3 lastPos;

    // Update is called once per frame
    void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            isPressed = true;
        }

        if (Input.GetMouseButton(0))
        {
            if (OnTouch != null)
                OnTouch.Invoke();
        }

        if (Input.GetMouseButtonUp(0))
        {
            isPressed = false;

            if(OnTouchUp != null)
                OnTouchUp.Invoke();
        }

        var currentPosition = Input.mousePosition;
        delta = currentPosition - lastPos;
        lastPos = currentPosition;
    }



}
