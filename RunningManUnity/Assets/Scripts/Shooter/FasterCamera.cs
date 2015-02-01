using UnityEngine;
using System.Collections;

// Temporarily freezes the camera
public class FasterCamera : ShooterAbility 
{
    public FasterCamera(Shooter shooter)
        : base(shooter)
    {
        this.abilityName = "Faster";
        energyCost = 500;
        this.iconString = "ShooterPowerSpeedUp";

        limitedUses = true;
        usesLeft = 1;
    }


    protected override void CastAbility()
    {
        base.CastAbility();

        // Stop the camera from moving
        GameObject go = (GameObject)GameObject.Instantiate(Resources.Load("Faster Camera"), shooter.getMousePosition(), Quaternion.identity);
    }
}
