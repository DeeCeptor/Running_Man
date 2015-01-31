﻿using UnityEngine;
using System.Collections;

public class SpawnDog : ShooterAbility {

    public override void CastAbility()
    {
        base.CastAbility();

        // Fire bullet
        GameObject go = (GameObject)Instantiate(Resources.Load("Dog"), shooter.getMousePosition(), Quaternion.identity);

        // Set damage
        DamageOnHit dmg = go.GetComponent<DamageOnHit>();
        dmg.damageOnHit = damage;

        // Set speed of bullet
        EnemyWalking walking = go.GetComponent<EnemyWalking>();
        walking.speed = 5;
    }
}