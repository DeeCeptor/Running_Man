using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    float walkForce = 10.0f;
    float jumpForce = 20.0f;
    //keyAbility Ability;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody2D.velocity = new Vector2(walkForce, rigidbody2D.velocity.y);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody2D.velocity = new Vector2(-1.0f*walkForce, rigidbody2D.velocity.y);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, -0.5f*jumpForce);
        }

	}
}
