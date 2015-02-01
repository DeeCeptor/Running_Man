using UnityEngine;
using System.Collections;

public class DamageOnHit : MonoBehaviour 
{
	public float damageOnHit = 10;
    public bool destroyOnHit = true;
    public bool destroyOnGround = false;
    public bool createsExplosion = true;
    public bool destroyOnAnyCollision = false;
    public float explosionScaleFactor = 1;

	void Start () {
	
	}
	

	void Update () {
	
	}


	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.tag == "Runner")
		{
			coll.gameObject.SendMessage("TakeHit", damageOnHit);

            if (destroyOnHit)
            {
                RemoveObject();
            }
		}
        else if (destroyOnGround && coll.collider.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            RemoveObject();
        }
        else if(destroyOnAnyCollision)
        {
            RemoveObject();
        }
	}


    public void RemoveObject()
    {
        if (createsExplosion)
        {
            GameObject go = (GameObject)GameObject.Instantiate(Resources.Load("Explosion"), this.transform.position, Quaternion.identity);
            go.transform.localScale *= explosionScaleFactor;
        }

        Destroy(this.gameObject);
    }
}
