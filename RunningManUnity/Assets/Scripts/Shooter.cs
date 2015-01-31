using UnityEngine;
using System.Collections;

// Handles mouse controls
public class Shooter : MonoBehaviour 
{
	// Energy is what the shooter expends to cast abilities to kill the runner
	int maxEnergy = 1000;
    int curEnergy = 0;
    int rechargeRate = 5;

	GameObject runner;

	
	void Start () 
	{
		runner = GameObject.Find("Runner");
	}

	
	void Update () 
    {
        // Update energy
        if (curEnergy != maxEnergy)
        {
            curEnergy = Mathf.Min(curEnergy + rechargeRate, maxEnergy);
        }

		if (Input.GetMouseButtonDown(0))	// Left click
		{
			fireLeftClick();
		}
		if (Input.GetMouseButtonDown(1))
		{
			fireRightClick();	// Right click
		}
		if (Input.GetMouseButtonDown(2))
		{
			fireMiddleClick();	// Middle click
		}
	}


	public void fireLeftClick()
	{
		if(canUseAbility(10, 10))
		{
            curEnergy -= 10;

			// Fire bullet
			GameObject go = (GameObject)Instantiate(Resources.Load("Bullet"), getMousePosition(), Quaternion.identity);
			Vector3 velocity = 5 * Vector3.Normalize(runner.transform.position - getMousePosition());
            velocity.y = 0;
            velocity.z = 0;
            go.rigidbody2D.velocity = velocity;
			DamageOnHit dmg = go.GetComponent<DamageOnHit>();
            dmg.damageOnHit = 10;
		}
	}


	public void fireRightClick()
	{
        if (canUseAbility(10, 10))
		{
            curEnergy -= 10;

			// Fire bullet
			GameObject go = (GameObject)Instantiate(Resources.Load("Bullet"), getMousePosition(), Quaternion.identity);
            DamageOnHit dmg = go.GetComponent<DamageOnHit>();
            dmg.damageOnHit = 10;

            // Set speed of bullet
            go.rigidbody2D.velocity = 5 * Vector3.Normalize(runner.transform.position - getMousePosition());
		}
	}


	public void fireMiddleClick()
	{
		if(canUseAbility(1, 1))
		{
            curEnergy -= 10;

            // SPAWN DOGE!
            GameObject go = (GameObject)Instantiate(Resources.Load("Dog"), getMousePosition(), Quaternion.identity);
            DamageOnHit dmg = go.GetComponent<DamageOnHit>();
            dmg.damageOnHit = 10;
		}
	}


	public Vector3 getMousePosition()
	{
		Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		position.z = 0;
		return position;
		//	new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
	}


	// Checks the distance between the mouse and the runner man.
	// Returns true if mouse is at least distance away from runner
	public bool canUseAbility(float distance, float abilityCost)
	{
		if (curEnergy >= abilityCost && Vector3.Distance(getMousePosition(), Vector2.zero) > distance)
		{
			return true;
		}
		else
			return false;
	}



	void OnGUI() 
	{
		GUI.Label(new Rect(10, 10, 100, 20), "" + curEnergy + "/" + maxEnergy);
	}
}
