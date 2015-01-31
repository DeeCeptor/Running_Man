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

		}
	}


	public void fireRightClick()
	{
		if(canUseAbility(1, 1))
		{
			
		}
	}


	public void fireMiddleClick()
	{
		if(canUseAbility(1, 1))
		{
			
		}
	}


	// Checks the distance between the mouse and the runner man.
	// Returns true if mouse is at least distance away from runner
	public bool canUseAbility(float distance, float abilityCost)
	{
		if (Vector3.Distance(Input.mousePosition, Vector2.zero) < distance)
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
