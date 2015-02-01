using UnityEngine;
using System.Collections;

public class DamageOnHit : MonoBehaviour 
{
	public float damageOnHit = 10;
    public bool destroyOnHit = true;
    public bool destroyOnGround = false;
    public bool createsExplosion = true;


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
	}


    public void RemoveObject()
    {
        if (createsExplosion)
        {
            GameObject go = (GameObject)GameObject.Instantiate(Resources.Load("Explosion"), this.transform.position, Quaternion.identity);
        }

        Destroy(this.gameObject);
    }
}
