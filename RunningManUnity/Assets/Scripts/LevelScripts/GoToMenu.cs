using UnityEngine;
using System.Collections;

public class GoToMenu : MonoBehaviour {

	void Update () {
	    if (Input.anyKey)
        {
            Application.LoadLevel("Menu");
        }
	}
}
