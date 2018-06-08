using System;
using UnityEngine;

//#TODO Create the touch input module currently SideBar is generatin delta & pressed which should belong to touchInput
public class TouchInput : MonoBehaviour {

    public static Vector2 delta;
    public static bool isPressed;

    public static Action OnTouch;
    public static Action OnTouchUp;

    public static Action OnDragVertically;
    public static Action OnDragHorizontally;

    private Vector3 lastPos;
    public Vector2 m_delta;    


    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AppStack.Invoke();
        }

        if (Input.GetMouseButtonDown(0))
        {
            isPressed = true;
        }

        if (Input.GetMouseButton(0))
        {
            if (OnTouch != null)
                OnTouch.Invoke();

            //Detect amount of drag
            var y = Mathf.Abs(delta.y);
            var x = Mathf.Abs(delta.x);

            //Vertically moved
            if (y > x + 3)
            {
                if (OnDragVertically != null)
                    OnDragVertically.Invoke();
            }

            if (x > y + 3)
            {
                if (OnDragHorizontally != null)
                    OnDragHorizontally.Invoke();
            }

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

        m_delta = delta;
    }



}
