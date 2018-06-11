using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateBase : MonoBehaviour {

    public Coroutine m_TransitionInRoutine;
    public Coroutine m_TransitionOutRoutine;

    public virtual void Enter()
    {
        var coroutineService = CoroutineService.Instance;
        m_TransitionInRoutine = coroutineService.StartCoroutine(OnTransitionIn());
    }

    public virtual void Exit()
    {
        var coroutineService = CoroutineService.Instance;
        m_TransitionOutRoutine = coroutineService.StartCoroutine(OnTransitionOut());
    }

    public virtual void ExitImmediately()
    {
        OnTransitionOut();
    }

    public abstract IEnumerator OnTransitionIn();
    public abstract IEnumerator OnTransitionOut();
    public virtual void Toggle() { }
}
