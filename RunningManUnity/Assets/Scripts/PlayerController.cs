using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour {

    float walkForce = 5.0f;
    float jumpForce = 10.0f;
    bool grounded = true;
    int health = 1000;
    bool shield = false;
    bool left = false;
    bool right = true;
    int shieldhealth = 0;
    int Ability = 1;
    bool invuln = false;
    int abilitycount = 0;
    DateTime wait;
    public GameObject plane;
    public Texture2D heightmap;
    public Vector3 size = new Vector3(100, 10, 100);
    public Animator Anim;

    Texture2D texture;
    public LayerMask mask = -1;

	// Use this for initialization
	void Start () {
        Anim = gameObject.GetComponentInChildren<Animator>();
        //texture = this.ren.material.mainTexture;
	}
    void OnGUI()
    {
        GUI.Label(new Rect(10, 25, 100, 20), "" + health + "/1000");
    }
	// Update is called once per frame
	void Update () 
    {
        Debug.Log("a");
       // RaycastHit hit;
        //Debug.Log(Physics.Raycast(this.transform.position, new Vector3(0, 0, 1), out hit, 5, mask.value));
      //  Debug.Log(hit.textureCoord);
       // RaycastHit2D ray = Physics2D.Raycast(this.transform.position, new Vector3(1, 0), 5, mask.value);
        //Debug.Log(ray.transform);
       // Debug.Log(hit.textureCoord);
        /*
        int y = 0;
        while (y < texture.height)
        {
            int x = 0;
            while (x < texture.width)
            {
                //Color color = ((x & y) ? Color.white : Color.gray);
                Color color = 
                texture.SetPixel(x, y, color);
                ++x;

                
            }
            ++y;
        }
        texture.Apply();*/


        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody2D.velocity = new Vector2(walkForce, rigidbody2D.velocity.y);
            if (left &&!right)
            {
                this.transform.Rotate(180, 0, 0);
                /*
                Vector3 theScale = transform.localScale;
                theScale.z *= -1;
                transform.localScale = theScale;
                 * */
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
            rigidbody2D.velocity = new Vector2(-1.0f * walkForce, rigidbody2D.velocity.y);
            if (right &&!left)
            {
                this.transform.Rotate(180, 0, 0);
             /*
                Vector3 theScale = transform.localScale;
                theScale.z *= -1;
                transform.localScale = theScale;
             * */
            }
            left = true;
            right = false;

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
            if (grounded == true)
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
                grounded = false;
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

        /******
         * CODE FOR TEXTURE SWITCHING BELOW
         * ABANDON HOPE ALL YE WHO ENTER HERE
         */

      //  plane = GameObject.Find("background");
        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        //float currcolor = heightmap.GetPixel(x, y).grayscale;
        //Debug.Log(currcolor);

	}

    void OnCollisionStay2D(Collision2D otherCollider)
    {
        if (otherCollider.collider.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            grounded = true; //wall jumping ahoy!
        }
    }

    void OnCollisionEnter2D(Collision2D otherCollider)
    {

        if (otherCollider.collider.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            grounded = true; 
        }

        if (otherCollider.collider.gameObject.layer == LayerMask.NameToLayer("healthpack"))
        //separate block to avoid screwing with shield code
        {
            health = health + 100;
            if (health > 1000)
            {
                health = 1000;
            }
        }

        if (otherCollider.collider.gameObject.layer == LayerMask.NameToLayer("shield"))
        { //acquire shield here
            shield = true;
            shieldhealth = 250;
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
            Debug.Log("player health");
            Debug.Log(health);
        }
    }
    
    //pass in an array parameter pair, first one is ability id, second is number of charges

    void getPower(int[] powerinfo) {
        Ability = powerinfo[0];
        abilitycount = powerinfo[1];
    }

}
