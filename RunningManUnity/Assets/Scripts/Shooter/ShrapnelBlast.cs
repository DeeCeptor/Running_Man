using UnityEngine;
using System.Collections;

public class ShrapnelBlast : ShooterAbility 
{
    int numberOfShrapnel = 20;

    public ShrapnelBlast(Shooter shooter)
        : base(shooter)
    {
        this.abilityName = "Shrapnel";
        energyCost = 300;
        this.iconString = "ShrapnelIconMine";

        usesLeft = 3;
        damage = 50;
    }


    protected override void CastAbility()
    {
        base.CastAbility();

        // Create a blast of shrapnel fountaining upwards
        for (int x = 0; x < numberOfShrapnel; x++)
        {
            GameObject go = (GameObject)GameObject.Instantiate(Resources.Load("Shrapnel"), shooter.getMousePosition(), Quaternion.identity);

            // Set damage
            DamageOnHit dmg = go.GetComponent<DamageOnHit>();
            dmg.damageOnHit = damage;
            dmg.destroyOnGround = true;

            // Set velocity upwards with a random X component
            go.rigidbody2D.velocity = new Vector2(randomNumber(-300, 300, 100), randomNumber(400, 600, 100));
        }
    }

    public float randomNumber(int min, int max, float divideByFactor)
    {
        return Random.Range(min, max) / divideByFactor;
    }
}
