using System;
using System.Collections;
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

    public Canvas parentCanvas;

    private Vector3 firstPosition;
    public static bool isMovingHorizontally;
    public float minimumDrag = 2;

    private void Awake()
    {
        Input.multiTouchEnabled = false;
    }

    public void Start()
    {
        Vector2 pos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentCanvas.transform as RectTransform, Input.mousePosition,
            parentCanvas.worldCamera,
            out pos);
    }


    // Update is called once per frame
    void Update () {

        Vector2 movePos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentCanvas.transform as RectTransform,
            Input.mousePosition, parentCanvas.worldCamera,
            out movePos);

        var currentPosition = parentCanvas.transform.TransformPoint(movePos);

        delta = currentPosition - lastPos;
        lastPos = currentPosition;

        m_delta = delta;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AppStack.Invoke();
        }

        if (Input.GetMouseButtonDown(0))
        {
            isPressed = true;
            firstPosition = parentCanvas.transform.TransformPoint(movePos);
        }

        if (Input.GetMouseButton(0))
        {
            if (OnTouch != null)
                OnTouch.Invoke();

            var secondPosition = parentCanvas.transform.TransformPoint(movePos);

            var movedDelta = firstPosition - secondPosition;

            if (Mathf.Abs(movedDelta.x) > minimumDrag)
            {
                //You've moved!
                isMovingHorizontally = true;
            }
            else {
                isMovingHorizontally = false;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isPressed = false;

            if(OnTouchUp != null)
                OnTouchUp.Invoke();

            isMovingHorizontally = false;
        }

    }



}
