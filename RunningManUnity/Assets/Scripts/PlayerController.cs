using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    float walkForce = 5.0f;
    float jumpForce = 10.0f;
    bool grounded = true;
    int health = 1000;
    int healthMax = 1000;
    bool shield = false;
    bool left = false;
    bool right = true;
    int shieldhealth = 0;
    int Ability = 1;
    bool invuln = false;
    int abilitycount = 0;
	bool sprinting = false;
	float sprintFactor = 1.5f;
    DateTime wait;
    public GameObject plane;
    public Texture2D heightmap;
    public Vector3 size = new Vector3(100, 10, 100);
    public Animator Anim;
    Slider healthBar;
    Slider shieldBar;
    public AudioClip scream;


    Texture2D texture;
    public LayerMask mask = -1;

	// Use this for initialization
	void Start () 
    {
        Anim = gameObject.GetComponentInChildren<Animator>();
        healthBar = GameObject.Find("Runner HP").GetComponent<Slider>();
        shieldBar = GameObject.Find("Shield Bar").GetComponent<Slider>();
	}

	// Update is called once per frame
	void Update () 
    {

        if (grounded == false)
        {
            Anim.SetBool("isRunning", false);
            Anim.SetBool("isLanding", false);
            Anim.SetBool("isJumping", true);
            Anim.SetBool("isIdle", false);
            Anim.SetBool("isSliding", false);
        }
     

		// Check if we're sprinting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprintFactor = 1.5f;
            Anim.speed = 1.4f;
        }
        else
        {
            sprintFactor = 1;
            Anim.speed = 0.7f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody2D.velocity = new Vector2(walkForce * sprintFactor, rigidbody2D.velocity.y);
            if (left &&!right)
            {
                this.transform.Rotate(180, 0, 0);
            }
            right = true;
            left = false;
            if (grounded == true)
            {
                Anim.SetBool("isRunning", true);
                Anim.SetBool("isLanding", false);
                Anim.SetBool("isJumping", false);
                Anim.SetBool("isIdle", false);
                Anim.SetBool("isSliding", false);
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
			rigidbody2D.velocity = new Vector2(-1.0f * walkForce * sprintFactor, rigidbody2D.velocity.y);
            if (right &&!left)
            {
                this.transform.Rotate(180, 0, 0);
            }
            left = true;
            right = false;
            
            if (!grounded) {
                Anim.SetBool("isRunning", false);
                Anim.SetBool("isLanding", false);
                Anim.SetBool("isJumping", true);
                Anim.SetBool("isIdle", false);
                Anim.SetBool("isSliding", false);

            }

            if (grounded == true)
            {
                Anim.SetBool("isRunning", true);
                Anim.SetBool("isLanding", false);
                Anim.SetBool("isJumping", false);
                Anim.SetBool("isIdle", false);
                Anim.SetBool("isSliding", false);
            }
        }
        else
        {
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
            if (grounded == true)
            {

                Anim.SetBool("isRunning", false);
                Anim.SetBool("isLanding", false);
                Anim.SetBool("isJumping", false);
                Anim.SetBool("isIdle", true);
                Anim.SetBool("isSliding", false);
                
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("jumping");
            if (grounded)
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
                Anim.SetBool("isRunning", false);
                Anim.SetBool("isLanding", false);
                Anim.SetBool("isJumping", true);
                Anim.SetBool("isIdle", false);
                Anim.SetBool("isSliding", false);
           }
        }


        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            if (grounded == true)
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, -0.01f * jumpForce); //make it more responsive, terminate jump on release
                //grounded = false;
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (grounded)
            {
                Anim.SetBool("isRunning", false);
                Anim.SetBool("isLanding", false);
                Anim.SetBool("isJumping", false);
                Anim.SetBool("isIdle", false);
                Anim.SetBool("isSliding", true);
            }
            rigidbody2D.AddForce(new Vector2(rigidbody2D.velocity.x, -1.5f*jumpForce));
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (abilitycount > 0) //if any charges left, activate here
            {
                {
                    abilitycount -= 1;
                    callAbility();
                }
            }
        }

        if (DateTime.Now == wait && invuln == true)
        {
            invuln = false;
        }

        // Update health bar
        healthBar.normalizedValue = (float) ((float) health / (float) healthMax);
        shieldBar.normalizedValue = (float)((float)shieldhealth / (float) 250);
	}

    void OnCollisionStay2D(Collision2D otherCollider)
    {
        if (otherCollider.collider.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            grounded = true; //wall jumping ahoy!
        }
    }

    void OnCollisionExit2D(Collision2D otherCollider)
    {
        if (otherCollider.collider.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            grounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D otherCollider)
    {

        if (otherCollider.collider.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            grounded = true; 
        }

        if (otherCollider.collider.gameObject.layer == LayerMask.NameToLayer("bottom"))
        {
            audio.PlayOneShot(scream, 1f);
        }

        if (otherCollider.collider.gameObject.layer == LayerMask.NameToLayer("healthpack"))
        //separate block to avoid screwing with shield code
        {
            health = health + 100;
            if (health > 1000)
            {
                health = 1000;
            }
            Destroy(otherCollider.collider.gameObject);
        }

        if (otherCollider.collider.gameObject.layer == LayerMask.NameToLayer("shield"))
        { //acquire shield here
            shield = true;
            shieldhealth = 250;
            Debug.Log("got shield");
            Destroy(otherCollider.collider.gameObject);
        }

    }

    void callAbility() //add more abilities here, see getPower() for param details, abilities are just activated here
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
        }
    }
    
    //pass in an array parameter pair, first one is ability id, second is number of charges

    void getPower(int[] powerinfo) {
        Ability = powerinfo[0];
        abilitycount = powerinfo[1];
    }

}
