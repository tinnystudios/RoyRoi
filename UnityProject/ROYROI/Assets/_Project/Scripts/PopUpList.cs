using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PopUpList : StateBase
{
    public bool isActive = false;
    public GameObject content;
    public GameObject blocker;

    public MenuButton menuButton;

    private Button[] buttons;
    private Dictionary<GameObject, Button> buttonGameObjectLookUp = new Dictionary<GameObject, Button>();

    private void Awake()
    {
        buttons = GetComponentsInChildren<Button>(includeInactive:true);

        foreach (var b in buttons) {
            buttonGameObjectLookUp.Add(b.gameObject,b);
        }

        Exit();
    }

    public override void Toggle()
    {
        isActive = !isActive;

        if (isActive)
        {
            Enter();
        }
        else
        {
            Exit();
        }
    }

    private void Update()
    {
        if (!isActive)
            return;

        var currentSelectedObject = EventSystem.current.currentSelectedGameObject;

        if (currentSelectedObject == null)
            return;

        if (Input.GetMouseButtonUp(0))
        {
            if (currentSelectedObject != menuButton.gameObject)
            {
                Toggle();
            }
        }

    }

    private void OnDisable()
    {
        SetActiveState(false);
    }

    public override IEnumerator OnTransitionIn()
    {
        SetActiveState(true);
        yield break;
    }

    public override IEnumerator OnTransitionOut()
    {
        SetActiveState(false);
        yield break;
    }

    public void SetActiveState(bool active) {
        isActive = active;
        blocker.SetActive(active);
        //content.SetActive(active);
    }

}
