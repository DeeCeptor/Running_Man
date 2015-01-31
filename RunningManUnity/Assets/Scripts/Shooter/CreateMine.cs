using UnityEngine;
using System.Collections;

public class CreateMine : ShooterAbility {

    public CreateMine(Shooter shooter) : base(shooter)
    {
        
    }

    protected override void CastAbility()
    {
        base.CastAbility();

        // Mine
        GameObject go = (GameObject)Instantiate(Resources.Load("Mine"), shooter.getMousePosition(), Quaternion.identity);

        // Set damage
        DamageOnHit dmg = go.GetComponent<DamageOnHit>();
        dmg.damageOnHit = damage;
    }
}
