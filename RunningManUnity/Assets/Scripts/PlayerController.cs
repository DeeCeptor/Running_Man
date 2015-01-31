using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour {

    float walkForce = 5f;
    float jumpForce = 10.0f;
    bool grounded = true;
    int health = 1000;
    bool shield = false;
    bool left = false;
    bool right = false;
    int shieldhealth = 0;
    int Ability = 1;
    bool invuln;
    DateTime wait;
	// Use this for initialization
	void Start () {
	
	}
    void OnGUI()
    {
        GUI.Label(new Rect(10, 25, 100, 20), "" + health + "/1000");
    }
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody2D.velocity = new Vector2(walkForce, rigidbody2D.velocity.y);
            right = true;
            left = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody2D.velocity = new Vector2(-1.0f * walkForce, rigidbody2D.velocity.y);
            left = true;
            right = false;
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
            rigidbody2D.AddForce(new Vector2(rigidbody2D.velocity.x, -1.5f*jumpForce));
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            callAbility();
        }
        if (DateTime.Now == wait && invuln == true)
        {
            invuln = false;
        }


	}

    void OnCollisionEnter2D(Collision2D otherCollider)
    {
        if (otherCollider.collider.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
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
    }

    void callAbility()
    {
        switch (Ability)
        {
            case 0: //blink
                if (right == true)
                {
                    transform.position = new Vector2(transform.position.x + 5, transform.position.y);
                }
                else
                {
                    transform.position = new Vector2(transform.position.x - 5, transform.position.y);
                }
                break;
            case 1: //temporary invuln
                /*
                 * This one is a bit weird due to datetime reqs, basically set the time to turn it off here
                 * then in update do the check for when to turn off invulnerability
                 */
                wait = DateTime.Now.AddSeconds(2);
                invuln = true;
                break;
        }
    }

    void TakeHit(int damage) {
        if (invuln)
        {
            damage = 0;
        }
        if (shield)
        {
            shieldhealth = shieldhealth - damage;
            if (shieldhealth < 0)
            {
                health = health - shieldhealth;
                shieldhealth = 0;
                shield = false;
            }
        }
        else
        {
            health = health - damage;
            Debug.Log("player health");
            Debug.Log(health);
        }
    }

}
