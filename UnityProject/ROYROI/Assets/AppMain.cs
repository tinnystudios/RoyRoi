using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppMain : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //Set the correct application setup
        Screen.fullScreen = false;
        ApplicationChrome.statusBarState = ApplicationChrome.States.VisibleOverContent;
    }

}
