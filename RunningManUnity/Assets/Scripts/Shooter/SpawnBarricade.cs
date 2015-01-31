using UnityEngine;
using System.Collections;

public class SpawnBarricade : ShooterAbility {

    public override void CastAbility()
    {
        base.CastAbility();

        // Create barricade
        GameObject go = (GameObject)Instantiate(Resources.Load("Barricade"), shooter.getMousePosition(), Quaternion.identity);
    }
}
