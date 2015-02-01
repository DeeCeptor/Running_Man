using UnityEngine;
using System.Collections;

public class GoToMenu : MonoBehaviour {

	void Update () {
	    if (Input.GetKeyDown(KeyCode.Enter))
        {
            Application.LoadLevel("Menu");
        }
	}
}
