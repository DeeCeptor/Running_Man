using UnityEngine;
using System.Collections;

// When grounded the enemy moves towards the player
public class EnemyWalking : MonoBehaviour 
{
    bool grounded = false;
    GameObject runner;
    float speed = 5;

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
            Debug.Log("woof");
            grounded = true;


            Debug.Log("walking");
            Vector3 velocity = Vector3.Normalize(runner.transform.position - this.transform.position) * speed;
            velocity.y = 0;
            velocity.z = 0;
            this.rigidbody2D.velocity = velocity;
            //rigidbody2D.AddForce(velocity);
        }
    }
}
