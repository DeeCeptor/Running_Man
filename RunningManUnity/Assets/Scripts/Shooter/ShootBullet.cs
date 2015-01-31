using UnityEngine;
using System.Collections;

public class ShootBullet : ShooterAbility 
{
    public bool angledBullets = false;

    public ShootBullet(Shooter shooter)
        : base(shooter)
    {
        this.abilityName = "Bullet";
        energyCost = 300;

        damage = 10;
    }


    protected override void CastAbility()
    {
        base.CastAbility();

        // Fire bullet
        GameObject go = (GameObject)GameObject.Instantiate(Resources.Load("Bullet"), shooter.getMousePosition(), Quaternion.identity);
       
        // Set damage
        DamageOnHit dmg = go.GetComponent<DamageOnHit>();
        dmg.damageOnHit = damage;
        dmg.destroyOnGround = true;

        // Set speed of bullet
        Vector3 velocity = speed * Vector3.Normalize(shooter.runner.transform.position - shooter.getMousePosition());
        go.rigidbody2D.velocity = velocity;

        // Rotate to look towards player
        go.transform.rotation = Quaternion.LookRotation(go.rigidbody2D.velocity);
    }
}
