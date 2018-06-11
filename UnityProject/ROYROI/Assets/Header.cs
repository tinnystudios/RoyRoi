using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Header : StateBase
{

    public override IEnumerator OnTransitionIn()
    {
        gameObject.SetActive(true);
        yield break;
    }

    public override IEnumerator OnTransitionOut()
    {
        gameObject.SetActive(false);
        yield break;
    }
}
