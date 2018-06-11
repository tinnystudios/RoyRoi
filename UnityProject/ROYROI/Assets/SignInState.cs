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
        Enter();
    }

    public override IEnumerator OnTransitionIn()
    {
        yield return base.OnTransitionIn();

        m_Header.Exit();
        nav.Exit();

        yield break;
    }

    public override IEnumerator OnTransitionOut()
    {
        yield return base.OnTransitionOut();

        m_Header.Enter();
        nav.Enter();

        yield break;
    }
}
