using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageController : MonoBehaviour {

    public PageState m_CurrentPage;

    public void Awake()
    {
        var pages = GetComponentsInChildren<PageState>(includeInactive: true);

        foreach (var page in pages) {

            if (page == m_CurrentPage)
            {
                page.Enter();
            }
            else
            {
                page.Exit();
            }

        }

    }
}
