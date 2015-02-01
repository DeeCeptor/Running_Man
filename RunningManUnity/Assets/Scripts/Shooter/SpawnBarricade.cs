using UnityEngine;
using System.Collections;

public class SpawnBarricade : ShooterAbility {

    public SpawnBarricade(Shooter shooter)
        : base(shooter)
    {
        this.abilityName = "Barricade";
        energyCost = 600;
        this.iconString = "ShooterIconBarricade";
    }


    protected override void CastAbility()
    {
        base.CastAbility();

        // Create barricade
        GameObject go = (GameObject)GameObject.Instantiate(Resources.Load("Barricade"), shooter.getMousePosition(), Quaternion.identity);
    }
}
