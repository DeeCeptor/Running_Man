﻿using UnityEngine;
using System.Collections;

public class ShooterPowerup : MonoBehaviour {
    Shooter shooter;
    ShooterAbility[] potentialAbilities = new ShooterAbility[4];
    ShooterAbility abilityGiven;
    SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
        shooter = GameObject.Find("Shooter").GetComponent<Shooter>();

	    // Determine what type of powerup this is
        potentialAbilities[0] = new ShrapnelBlast(shooter);
        potentialAbilities[1] = new ShrapnelBlast(shooter);
        potentialAbilities[2] = new FasterCamera(shooter);
        potentialAbilities[3] = new StopCamera(shooter);

        abilityGiven = potentialAbilities[Random.Range(0, potentialAbilities.Length)];

        renderer = this.GetComponent<SpriteRenderer>();
        renderer.sprite = Resources.Load(abilityGiven.iconString, typeof(Sprite)) as Sprite;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnMouseDown()
    {
        shooter.changeRightClickAbility(abilityGiven);
        Debug.Log("Shooter got " + abilityGiven.abilityName);
        Destroy(this.gameObject);
    }
}
