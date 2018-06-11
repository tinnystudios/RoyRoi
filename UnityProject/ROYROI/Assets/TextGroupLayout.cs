using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class TextGroupLayout : MonoBehaviour {

    public List<Text> m_Texts = new List<Text>();
    public TextStyle m_TextStyle;

    void Update()
    {
        if (m_TextStyle == null)
            return;

        GetComponentsInChildren(true, m_Texts);

        foreach (var t in m_Texts)
        {
            t.fontSize = m_TextStyle.m_FontSize;
            t.font = m_TextStyle.m_Font;
        }
    }

}
