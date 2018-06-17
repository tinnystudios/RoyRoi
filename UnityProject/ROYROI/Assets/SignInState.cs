using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignInState : PageState
{
    public NavigationBar nav;
    public Header m_Header;

    public HomeState m_HomeState;

    public const string PrefSignedIn = "SignState";

    private void Awake()
    {
        if (PlayerPrefs.HasKey(PrefSignedIn))
        {
            m_HomeState.Enter();
        }
        else
        {
            m_Header.Exit();
            nav.Exit();
        }
    }

    public void SignIn()
    {
        //Success
        PlayerPrefs.SetInt(PrefSignedIn, 1);
        m_HomeState.Enter();
    }

    public void SignOut()
    {
        PlayerPrefs.DeleteKey(PrefSignedIn);

        m_Header.Exit();
        nav.Exit();

        Enter();
    }

    public override IEnumerator OnTransitionIn()
    {
        yield return base.OnTransitionIn();
        yield break;
    }

    public override IEnumerator OnTransitionOut()
    {
        yield return base.OnTransitionOut();
        yield break;
    }
}
