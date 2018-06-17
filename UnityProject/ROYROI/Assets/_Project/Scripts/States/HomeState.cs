using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeState : PageState {

    public NavigationBar m_Nav;
    public Header m_Header;

    public override IEnumerator OnTransitionIn()
    {
        m_Nav.Enter();
        m_Header.Enter();
        return base.OnTransitionIn();
    }

    public override IEnumerator OnTransitionOut()
    {
        return base.OnTransitionOut();
    }
}
