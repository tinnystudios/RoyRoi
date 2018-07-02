using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertService : Singleton<AlertService>
{
    public AnimationCurve mFadeCurve;
    public AnimationCurve mScaleCurve;

    public CanvasGroup mCanvasGroup;
    public float coolDown = 2;
    private Coroutine CoolDownRoutine;

    private void Awake()
    {
        Hide(immediate: true);
    }

    public void Show(bool immediate = false)
    {
        if (CoolDownRoutine == null)
        {
            CoolDownRoutine = StartCoroutine(CoolDown(coolDown));
        }
        else
        {
            return;
        }

        if (!immediate)
            Transition(1, Vector3.one, 0.3F);
        else
        {
            mCanvasGroup.alpha = 1;
            mCanvasGroup.transform.localScale = Vector3.one;
        }
    }

    private IEnumerator CoolDown(float duration)
    {
        yield return new WaitForSeconds(duration);
        yield return Hide();
        CoolDownRoutine = null;
    }

    public Coroutine Hide(bool immediate = false)
    {
        if (!immediate)
            return Transition(0, Vector3.zero, 0.3F);
        else
        {
            mCanvasGroup.alpha = 0;
            mCanvasGroup.transform.localScale = Vector3.zero;
            return null;
        }
    }

    private Coroutine Transition(float alphaB, Vector3 scaleB, float length)
    {
        return StartCoroutine(DoTransition(alphaB,scaleB,length));
    }

    private IEnumerator DoTransition(float alphaB,Vector3 scaleB,float length)
    {
        var alphaA = mCanvasGroup.alpha;
        var scaleA = mCanvasGroup.transform.localScale;

        for (float i = 0; i < 1.0F; i += Time.deltaTime / length)
        {
            mCanvasGroup.alpha = Mathf.Lerp(alphaA, alphaB, mFadeCurve.Evaluate(i));
            mCanvasGroup.transform.localScale = Vector3.Lerp(scaleA, scaleB, mScaleCurve.Evaluate(i));
            yield return null;
        }
    }

}
