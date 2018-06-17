using ROYROI.Buttons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListMapToggle : SpriteToggle {

    public GameObject m_ContentOn;
    public GameObject m_ContentOff;

    public Text m_Text;

    public override void Off()
    {
        base.Off();
        m_ContentOff.SetActive(true);
        m_ContentOn.SetActive(false);
        m_Text.text = "Map View";
    }

    public override void On()
    {
        base.On();
        m_ContentOff.SetActive(false);
        m_ContentOn.SetActive(true);
        m_Text.text = "List View";
    }
}
