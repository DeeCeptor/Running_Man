using UnityEngine;
using System.Collections;

public class CreateMine : ShooterAbility {

    public override void CastAbility()
    {
        base.CastAbility();

        // Fire bullet
        GameObject go = (GameObject)Instantiate(Resources.Load("Mine"), shooter.getMousePosition(), Quaternion.identity);

        // Set damage
        DamageOnHit dmg = go.GetComponent<DamageOnHit>();
        dmg.damageOnHit = damage;
    }
}
