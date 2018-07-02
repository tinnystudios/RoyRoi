using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeState : PageState {

    public List<string> m_EventStacks = new List<string>();

    public NavigationBar m_Nav;
    public Header m_Header;

    void Update()
    {
        m_EventStacks.Clear();

        foreach (var stack in AppStack.Stacks)
        {
            m_EventStacks.Add(stack.ToString());
        }
    }

    public override IEnumerator OnTransitionIn()
    {
        AppStack.Clear();

        m_Nav.Enter();
        m_Header.Enter();
        return base.OnTransitionIn();
    }

    public override IEnumerator OnTransitionOut()
    {
        return base.OnTransitionOut();
    }

    public override void OnEnterStack()
    {
        base.OnEnterStack();
    }
}
