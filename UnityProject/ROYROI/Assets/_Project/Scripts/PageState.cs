using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PageState : StateBase, IEventStack
{
    public GameObject header;
    public GameObject content;

    public static PageState CurrentPage { get; set; }

    public override void Enter()
    {
        if (CurrentPage == this) {
            return;
        }

        if (CurrentPage != null)
        {
            CurrentPage.Exit();
        }

        CurrentPage = this;
        base.Enter();
    }

    public override void Exit()
    {
        AppStack.Add(this);
        base.Exit();
    }

    public void Exit(bool includeStack) {
        if (includeStack)
            this.Exit();

        else base.Exit();
    }

    public void OnEnterStack()
    {
        Enter();
    }

    public override IEnumerator OnTransitionIn()
    {
        if (header != null) header.SetActive(true);
        if (content != null) content.SetActive(true);
        yield break;
    }

    public override IEnumerator OnTransitionOut()
    {
        if (header != null) header.SetActive(false);
        if (content != null) content.SetActive(false);
        yield break;
    }
}
