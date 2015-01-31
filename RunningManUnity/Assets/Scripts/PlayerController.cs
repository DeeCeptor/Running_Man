using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    float walkForce = 2.5f;
    float jumpForce = 5.0f;
    bool grounded = true;
    int health = 1000;
    //Ability Ability;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody2D.velocity = new Vector2(walkForce, rigidbody2D.velocity.y);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody2D.velocity = new Vector2(-1.0f * walkForce, rigidbody2D.velocity.y); 
        }
        else
        {
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (grounded == true)
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
                grounded = false;
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rigidbody2D.AddForce(new Vector2(rigidbody2D.velocity.x, -0.5f*jumpForce));
        }

	}

    void OnCollisionEnter2D(Collision2D otherCollider)
    {
        if (otherCollider.collider.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            Debug.Log("Collding");
            grounded = true;
        }
        if (otherCollider.collider.gameObject.layer == LayerMask.NameToLayer("healthpack"))
        {
            health = health + 100;
            if (health > 1000)
            {
                health = 1000;
            }
        }
        if (otherCollider.collider.gameObject.layer == LayerMask.NameToLayer("bullet"))
        {
           // TakeHit();
        }
    }

    void TakeHit(int damage) {
        health = health - damage;
    }

}
