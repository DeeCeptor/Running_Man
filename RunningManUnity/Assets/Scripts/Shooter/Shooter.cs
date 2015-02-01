﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

// Handles mouse controls
public class Shooter : MonoBehaviour 
{
	// Energy is what the shooter expends to cast abilities to kill the runner
	int maxEnergy = 700;
    int curEnergy = 0;
    int rechargeRate = 500;
    int normalRechargeRate = 500;
    float shooterTimeScale = 1.0f;  // Can be changed for slow motion

    [HideInInspector]
	public GameObject runner;
    Image middleClickText;
    Image rightClickText;

    Slider energyBar;   // Shows how much energy is remaining

    // Abilities
    ShooterAbility leftClickAbility;
    ShooterAbility middleClickAbility;
    ShooterAbility rightClickAbility;
    LinkedList<ShooterAbility> abilityList = new LinkedList<ShooterAbility>();

    // Left and middle click abilities
    ShootBullet shootBullet;
    SpawnDog spawnDog;
    SpawnBarricade spawnBarricade;
    CreateMine createMine;

    // Powerup abilities
    NoRightClick noRightClick;
    ShrapnelBlast shrapnelBlast;
    Explosives explosives;
    StopCamera stopCamera;
    FasterCamera fasterCamera;
	
	void Start () 
	{
		runner = GameObject.Find("Runner");
        energyBar = GameObject.Find("EnergyBar").GetComponent<Slider>();

        shootBullet = new ShootBullet(this);
        spawnDog = new SpawnDog(this);
        spawnBarricade = new SpawnBarricade(this);
        createMine = new CreateMine(this);

        // Right click powerup abilities
        noRightClick = new NoRightClick(this);
        shrapnelBlast = new ShrapnelBlast(this);
        explosives = new Explosives(this);
        stopCamera = new StopCamera(this);
        fasterCamera = new FasterCamera(this);

        abilityList.AddLast(createMine);
        abilityList.AddLast(spawnBarricade);
        abilityList.AddFirst(spawnDog);

        leftClickAbility = shootBullet;
        middleClickAbility = createMine;
        rightClickAbility = fasterCamera;

        // Grab GUI icons
        middleClickText = GameObject.Find("Middle Click Icon").GetComponent<Image>();
        rightClickText = GameObject.Find("Right Click Icon").GetComponent<Image>();

        middleClickText.sprite = Resources.Load(middleClickAbility.iconString, typeof(Sprite)) as Sprite;
	}

	
	void Update () 
    {
        // Update energy
        if (curEnergy != maxEnergy)
        {
            curEnergy = Mathf.Min((int)(curEnergy + (Time.deltaTime * rechargeRate) * shooterTimeScale), maxEnergy);
        }

        // Check scroll wheel
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
                scrollAbilityUp();
            else
                scrollAbilityDown();
        }

		if (Input.GetMouseButton(0))	// Left click
		{
            leftClickAbility.Cast();
		}
		if (Input.GetMouseButtonDown(1))    // Right click
		{
            if (rightClickAbility != null)
            {
                rightClickAbility.Cast();

                // Remove the ability if we're out of casts
                if (rightClickAbility.usesLeft <= 0)
                {
                    changeRightClickAbility(noRightClick);
                    rightClickText.sprite = null;
                }
            }
		}
		if (Input.GetMouseButtonDown(2))    // Middle click
		{
            middleClickAbility.Cast();
		}


        // Set the slider
        energyBar.normalizedValue = (float)curEnergy / maxEnergy;
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
        middleClickText.sprite = Resources.Load(middleClickAbility.iconString, typeof(Sprite)) as Sprite;
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
        middleClickText.sprite = Resources.Load(middleClickAbility.iconString, typeof(Sprite)) as Sprite;
    }
    public void changeRightClickAbility(ShooterAbility newAbility)
    {
        rightClickAbility = newAbility;
        rightClickText.sprite = Resources.Load(rightClickAbility.iconString, typeof(Sprite)) as Sprite;
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
        GUI.Label(new Rect(Screen.width - 30, 30, 100, 20), "" + rightClickAbility.abilityName + " " + rightClickAbility.usesLeft);
	}
}
