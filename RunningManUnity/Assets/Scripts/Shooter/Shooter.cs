using UnityEngine;
using System.Collections;

// Handles mouse controls
public class Shooter : MonoBehaviour 
{
	// Energy is what the shooter expends to cast abilities to kill the runner
	int maxEnergy = 700;
    int curEnergy = 0;
    int rechargeRate = 500;
    int normalRechargeRate = 500;

    [HideInInspector]
	public GameObject runner;


    // Abilities
    ShooterAbility leftClickAbility;
    ShooterAbility middleClickAbility;
    ShooterAbility rightClickAbility;

    // All abilities
    ShootBullet shootBullet;
    SpawnDog spawnDog;
    SpawnBarricade spawnBarricade;
    CreateMine createMine;
	
	void Start () 
	{
		runner = GameObject.Find("Runner");

        shootBullet.abilityName = "Fire Bullet";

        shootBullet = new ShootBullet(this);
        spawnDog = new SpawnDog(this);
        spawnBarricade = new SpawnBarricade(this);
        createMine = new CreateMine(this);

        leftClickAbility = shootBullet;
        middleClickAbility = createMine;
        rightClickAbility = spawnDog;
	}

	
	void Update () 
    {
        // Update energy
        if (curEnergy != maxEnergy)
        {
            curEnergy = Mathf.Min((int) (curEnergy + (Time.deltaTime * rechargeRate)), maxEnergy);
        }

		if (Input.GetMouseButtonDown(0))	// Left click
		{
            leftClickAbility.Cast();
		}
		if (Input.GetMouseButtonDown(1))    // Right click
		{
            rightClickAbility.Cast();
		}
		if (Input.GetMouseButtonDown(2))    // Middle click
		{
            middleClickAbility.Cast();
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


    public void loseEnergy(int amount)
    {
        curEnergy -= amount;
    }


	void OnGUI() 
	{
		GUI.Label(new Rect(10, 10, 100, 20), "" + curEnergy + "/" + maxEnergy);
	}
}
