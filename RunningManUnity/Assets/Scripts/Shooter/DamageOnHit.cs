using UnityEngine;
using System.Collections;

public class DamageOnHit : MonoBehaviour 
{
	public float damageOnHit = 10;
    public bool destroyOnHit = true;
    public bool destroyOnGround = false;


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
                Destroy(this.gameObject);
            }
		}
        else if (destroyOnGround && coll.collider.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            Destroy(this.gameObject);
        }
	}
}
