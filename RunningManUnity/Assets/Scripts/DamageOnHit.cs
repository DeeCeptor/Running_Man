using UnityEngine;
using System.Collections;

public class DamageOnHit : MonoBehaviour {
	public float damageOnHit = 10;

	void Start () {
	
	}
	

	void Update () {
	
	}


	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.tag == "Runner")
		{
			Debug.Log("Hit runner with " + damageOnHit);
			coll.gameObject.SendMessage("TakeHit", 10);

		}
	}
}
