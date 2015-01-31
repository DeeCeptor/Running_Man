﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
    LinkedList<ShooterAbility> abilityList = new LinkedList<ShooterAbility>();

    // All abilities
    ShootBullet shootBullet;
    SpawnDog spawnDog;
    SpawnBarricade spawnBarricade;
    CreateMine createMine;
	
	void Start () 
	{
		runner = GameObject.Find("Runner");

        shootBullet = new ShootBullet(this);
        spawnDog = new SpawnDog(this);
        spawnBarricade = new SpawnBarricade(this);
        createMine = new CreateMine(this);

        abilityList.AddLast(createMine);
        abilityList.AddLast(spawnBarricade);
        abilityList.AddFirst(spawnDog);

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

        // Check scroll wheel
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
                scrollAbilityUp();
            else
                scrollAbilityDown();
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


    public void scrollAbilityUp()
    {
        try
        {
            middleClickAbility = abilityList.Find(middleClickAbility).Next.Value;
        }
        catch (System.NullReferenceException)
        {
            middleClickAbility = abilityList.First.Value;
        }
    }
    public void scrollAbilityDown()
    {
        try
        {
            middleClickAbility = abilityList.Find(middleClickAbility).Previous.Value;
        }
        catch (System.NullReferenceException)
        {
            middleClickAbility = abilityList.Last.Value;
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
		if (curEnergy >= abilityCost && (Vector3.Distance(getMousePosition(), runner.transform.position) > distance))
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
		GUI.Label(new Rect(Screen.width - 80, 10, 100, 20), "" + curEnergy + "/" + maxEnergy);
        GUI.Label(new Rect(Screen.width - 120, 30, 100, 20), "" + leftClickAbility.abilityName);
        GUI.Label(new Rect(Screen.width - 80, 50, 100, 20), "" + middleClickAbility.abilityName);
        GUI.Label(new Rect(Screen.width - 30, 30, 100, 20), "" + rightClickAbility.abilityName);
	}
}
