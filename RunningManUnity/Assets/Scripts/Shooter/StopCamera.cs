using UnityEngine;
using System.Collections;

// Temporarily freezes the camera
public class StopCamera : ShooterAbility 
{
    public StopCamera(Shooter shooter)
        : base(shooter)
    {
        this.abilityName = "Freeze";
        energyCost = 500;

        limitedUses = true;
        usesLeft = 1;
    }


    protected override void CastAbility()
    {
        base.CastAbility();

        // Stop the camera from moving
        GameObject go = (GameObject)GameObject.Instantiate(Resources.Load("Freeze Camera"), shooter.getMousePosition(), Quaternion.identity);
    }
}
