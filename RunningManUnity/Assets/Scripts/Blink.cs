using UnityEngine;
using System.Collections;

public class Blink : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D otherCollider)
    {
        int[] powerinfo = new int[2];
        powerinfo[0] = 0;
        powerinfo[1] = 3;
        otherCollider.gameObject.SendMessage("getPower", powerinfo);
        Destroy(this);
    }

}
