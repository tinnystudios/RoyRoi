using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationBar : StateBase, ISubState
{
    public GameObject m_Content;

    private void Awake()
    {
        
    }

    public override IEnumerator OnTransitionIn()
    {
        m_Content.SetActive(true);
        yield break;
    }

    public override IEnumerator OnTransitionOut()
    {
        m_Content.SetActive(false);
        yield break;
    }

}
