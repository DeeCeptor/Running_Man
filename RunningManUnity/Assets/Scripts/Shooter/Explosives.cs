using UnityEngine;
using System.Collections;

// Spawns explosives that go off after a time
public class Explosives : ShooterAbility {
    
    public float countdownTime = 1.5f;
    public float radius = 2;


    public Explosives(Shooter shooter)
      : base(shooter)
    {
        this.abilityName = "Explosives";
        this.limitedUses = true;
        this.usesLeft = 3;
        this.iconString = "ShooterExplosive";

        damage = 100;
    }


    protected override void CastAbility()
    {
        base.CastAbility();

        // Spawn explosive
        GameObject go = (GameObject)GameObject.Instantiate(Resources.Load("Explosive"), shooter.getMousePosition(), Quaternion.identity);

        // Set damage
        ExplosiveCountdown explosive = go.GetComponent<ExplosiveCountdown>();
        explosive.countdownTime = 1.5f;
        explosive.damage = this.damage;
        explosive.blastRadius = radius;
    }
}
