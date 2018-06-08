using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGroup : MonoBehaviour {

    public ColorBlock m_SelectableColors;

    private List<Button> m_Buttons = new List<Button>();

    private void Awake()
    {
        GetComponentsInChildren(includeInactive: true, result: m_Buttons);

        foreach (var b in m_Buttons)
        {
            b.colors = m_SelectableColors;
        }
    }

}
