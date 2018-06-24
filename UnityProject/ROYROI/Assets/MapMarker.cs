using System.Collections;
using UnityEngine;

public class MapMarker : MonoBehaviour
{
    private Vector3 mStartScale;

    public float m_Duration;
    public AnimationCurve m_Curve;

    public void Awake()
    {
        mStartScale = transform.localScale;
        transform.localScale = Vector3.zero;
    }

    private void OnEnable()
    {
        this.SetScale(mStartScale, m_Duration, m_Curve);
    }

    private void OnDisable()
    {
        transform.localScale = Vector3.zero;
    }

}

public static class TransformExtensions
{
    public static Coroutine SetScale(this MonoBehaviour monobehaviour, Vector3 targetScale, float duration, AnimationCurve curve = null)
    {
        return monobehaviour.StartCoroutine(DoScale(monobehaviour.transform, targetScale, duration, curve));
    }

    private static IEnumerator DoScale(Transform target, Vector3 targetScale, float duration, AnimationCurve curve = null)
    {
        var a = target.localScale;
        for (float i = 0; i < 1.0F; i += Time.deltaTime / duration)
        {
            var output = (curve == null) ? curve.Evaluate(i) : i;
            target.localScale = Vector3.Lerp(a, targetScale, output);
            yield return null;
        }
    }
}