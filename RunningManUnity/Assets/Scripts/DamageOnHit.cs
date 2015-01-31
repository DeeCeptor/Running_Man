using UnityEngine;
using System.Collections;

public class DamageOnHit : MonoBehaviour {


	void Start () {
	
	}
	

	void Update () {
	
	}


	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.tag == "Runner")
		{
			coll.gameObject.SendMessage("TakeHit", 10);

		}
	}
}
