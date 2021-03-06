﻿using UnityEngine;
using System.Collections;

public class CreateMine : ShooterAbility {

    public CreateMine(Shooter shooter) : base(shooter)
    {
        this.abilityName = "Mine";
        energyCost = 500;
        this.iconString = "ShooterIconMine";

        damage = 400;
    }

    protected override void CastAbility()
    {
        base.CastAbility();

        // Mine
        GameObject go = (GameObject) GameObject.Instantiate(Resources.Load("Mine"), shooter.getMousePosition(), Quaternion.identity);
        
        // Set damage
        DamageOnHit dmg = go.GetComponent<DamageOnHit>();
        dmg.damageOnHit = damage;
        dmg.explosionScaleFactor = 4f;
    }
}
