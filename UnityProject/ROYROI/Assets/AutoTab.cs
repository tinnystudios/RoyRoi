using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoTab : MonoBehaviour {

    private InputField m_InputField;
    public Selectable m_NextSelectable;
    
    private void Awake()
    {
        m_InputField = GetComponent<InputField>();
        m_InputField.onValueChanged.AddListener(OnValueCompleted);
    }

    private void OnDestroy()
    {
        m_InputField.onValueChanged.RemoveListener(OnValueCompleted);
    }

    public void OnValueCompleted(string value)
    {
        if (value.Length >= m_InputField.characterLimit)
        {
            //Go to next tab
            m_NextSelectable.Select();
        }
    }
}
