using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class UpdateLayout : MonoBehaviour {

    private RectTransform m_RectTransform;

    private void Awake()
    {
        m_RectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(m_RectTransform);
    }
}
