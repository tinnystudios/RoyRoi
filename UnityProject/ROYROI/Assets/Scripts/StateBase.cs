using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateBase : MonoBehaviour {

    public virtual void Enter()
    {
        StartCoroutine(OnTransitionIn());
    }

    public virtual void Exit()
    {
        StartCoroutine(OnTransitionOut());
    }

    public abstract IEnumerator OnTransitionIn();
    public abstract IEnumerator OnTransitionOut();
    public virtual void Toggle() { }
}
