using UnityEngine;
using System.Collections;

public class Invuln : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D otherCollider)
    {
        int[] powerinfo = new int[2];
        powerinfo[0] = 1;
        powerinfo[1] = 1;
        otherCollider.gameObject.SendMessage("getPower", powerinfo);
        Destroy(gameObject);
        
    }
}
