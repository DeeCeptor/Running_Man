using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class GoToMenu : MonoBehaviour {

	void Update () {
	    if (Input.GetKeyDown(KeyCode.Return))
        {
            Application.LoadLevel("Menu");
        }
	}
}
