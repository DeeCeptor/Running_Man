using UnityEngine;
using System.Collections;

// When grounded the enemy moves towards the player
public class EnemyWalking : MonoBehaviour 
{
    bool grounded = false;
    GameObject runner;
    [HideInInspector]
    public float speed = 5;


	void Start () 
    {
        runner = GameObject.Find("Runner");
	}
	

    void Update () 
    {
        if (grounded)
        {

        }
	}


    void OnCollisionEnter2D(Collision2D otherCollider)
    {
        if (otherCollider.collider.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            grounded = true;

            // Once on the ground the enemy walks in the X direction of the player
            Vector3 velocity = Vector3.Normalize(runner.transform.position - this.transform.position) * speed;
            velocity.y = 0;
            velocity.z = 0;
            this.rigidbody2D.velocity = velocity;
            //rigidbody2D.AddForce(velocity);
        }
    }
}
