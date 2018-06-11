using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SignInButton : MonoBehaviour, IPointerClickHandler {

    public SignInState m_SignInState;

    public void OnPointerClick(PointerEventData eventData)
    {
        //Submit
        m_SignInState.SignIn();
    }
}
