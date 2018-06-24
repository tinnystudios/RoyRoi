using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageController : MonoBehaviour {

    public void Initialize(PageState initialPage)
    {
        //Initialize pages
        var pages = GetComponentsInChildren<PageState>(includeInactive: true);

        foreach (var page in pages) {

            if (page == initialPage)
            {
                //page.Enter();
            }
            else
            {
                page.Exit(false);
            }

        }

        initialPage.Enter();

    }
}
