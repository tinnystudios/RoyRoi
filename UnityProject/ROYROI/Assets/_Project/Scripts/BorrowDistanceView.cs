using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BorrowDistanceView : MonoBehaviour {
    public Text m_Text;

    public void UpdateDistance(float dist)
    {
        m_Text.text = dist.ToString("F0") + "Km";
    }
}
