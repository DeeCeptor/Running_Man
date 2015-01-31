using UnityEngine;
using System.Collections;

public class ShootBullet : ShooterAbility 
{
    public bool angledBullets = false;


    public override void CastAbility()
    {
        base.CastAbility();

        // Fire bullet
        GameObject go = (GameObject)Instantiate(Resources.Load("Bullet"), shooter.getMousePosition(), Quaternion.identity);

        // Set damage
        DamageOnHit dmg = go.GetComponent<DamageOnHit>();
        dmg.damageOnHit = damage;

        // Set speed of bullet
        Vector3 velocity = speed * Vector3.Normalize(shooter.runner.transform.position - shooter.getMousePosition());
        velocity.z = 0;
        if(!angledBullets)
            velocity.y = 0;
        go.rigidbody2D.velocity = velocity;
    }
}
