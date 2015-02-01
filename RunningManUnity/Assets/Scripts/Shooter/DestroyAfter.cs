using UnityEngine;
using System.Collections;

public class DestroyAfter : MonoBehaviour {

    public float duration = 2;  // Duration in seconds


	void Update () 
    {
        duration -= Time.deltaTime;

        // Die after X seconds
        if (duration <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}
