using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppEntrance : PageState
{
    public PageState m_StartingPage;

    public PageController m_PageController;
    public NavigationBar nav;
    public Header m_Header;

    public HomeState m_HomeState;
    public SignInState m_SignInState;

    private void Awake()
    {
        m_PageController.Initialize(m_StartingPage);

        if (IsEnterHome)
        {
            m_HomeState.Enter();
        }
        else 
        {
            m_Header.Exit();
            nav.Exit();

            if (IsEnterSignIn)
            {
                m_SignInState.Enter();
            } 
            
        }
    }

    public bool OnBoardingCompleted
    {
        get { return PlayerPrefs.HasKey(Prefs.Onboarding); }
    }

    public bool IsEnterHome
    {
        get
        {
            return PlayerPrefs.HasKey(Prefs.SignedIn);
        }
    }

    public bool IsEnterSignIn
    {
        get
        {
            return PlayerPrefs.HasKey(Prefs.Onboarding) && PlayerPrefs.HasKey(Prefs.SignedIn);
        }
    }
}
