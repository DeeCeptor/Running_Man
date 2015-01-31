using UnityEngine;
using System.Collections;

public class DamageOnHit : MonoBehaviour 
{
	public float damageOnHit = 10;
    public bool destroyOnHit = true;


	void Start () {
	
	}
	

	void Update () {
	
	}


	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.tag == "Runner")
		{
			coll.gameObject.SendMessage("TakeHit", 10f);

            if (destroyOnHit)
            {
                Debug.Log("Hit runner with " + damageOnHit);
                Destroy(this.gameObject);
            }
		}
	}
}
