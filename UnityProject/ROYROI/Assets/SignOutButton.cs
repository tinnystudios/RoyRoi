using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SignOutButton : MonoBehaviour, IPointerClickHandler
{
    public SignInState m_SignInState;

    public void OnPointerClick(PointerEventData eventData)
    {
        m_SignInState.SignOut();
    }
}
