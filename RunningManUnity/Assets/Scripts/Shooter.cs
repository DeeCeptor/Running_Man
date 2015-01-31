using UnityEngine;
using System.Collections;

// Handles mouse controls
public class Shooter : MonoBehaviour 
{
	// Energy is what the shooter expends to cast abilities to kill the runner
	int maxEnergy = 100;
	float curEnergy = 0;



	
	void Start () 
	{

	}

	
	void Update () {
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
		if(canUseAbility(1, 1))
		{
			// Fire bullet
			GameObject go = (GameObject)Instantiate(Resources.Load("Bullet"), getMousePosition(), Quaternion.identity);
			go.rigidbody2D.velocity = new Vector2(5, 0);
		}
	}


	public void fireRightClick()
	{
		if(canUseAbility(1, 1))
		{
			// Fire bullet
			GameObject go = (GameObject)Instantiate(Resources.Load("Bullet"), getMousePosition(), Quaternion.identity);
			go.rigidbody2D.velocity = new Vector2(5, 0);
		}
	}


	public void fireMiddleClick()
	{
		if(canUseAbility(1, 1))
		{
			
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
		if (Vector3.Distance(getMousePosition(), Vector2.zero) < distance)
		{
			return false;
		}
		else
			return true;
	}



	void OnGUI() 
	{
		GUI.Label(new Rect(10, 10, 100, 20), "" + curEnergy + "/" + maxEnergy);
	}
}
