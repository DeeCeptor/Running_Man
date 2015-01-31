using UnityEngine;
using System.Collections;

public class SpawnBarricade : ShooterAbility {

    public SpawnBarricade(Shooter shooter)
        : base(shooter)
    {
        
    }


    protected override void CastAbility()
    {
        base.CastAbility();

        // Create barricade
        GameObject go = (GameObject)Instantiate(Resources.Load("Barricade"), shooter.getMousePosition(), Quaternion.identity);
    }
}
