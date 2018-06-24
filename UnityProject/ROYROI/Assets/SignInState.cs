using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Prefs
{
    public const string Onboarding = "Onboarding";
    public const string SignedIn = "SignState";
}

public class SignInState : PageState
{
    public NavigationBar nav;
    public Header m_Header;

    public HomeState m_HomeState;

    public void SignIn()
    {
        //Success
        PlayerPrefs.SetInt(Prefs.SignedIn, 1);
        m_HomeState.Enter();
    }

    public void SignOut()
    {
        PlayerPrefs.DeleteKey(Prefs.SignedIn);

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
