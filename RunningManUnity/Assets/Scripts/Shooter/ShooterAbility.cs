using UnityEngine;
using System.Collections;

// Base class for other abilities to inherit
public class ShooterAbility
{
    protected Shooter shooter;
    public int energyCost;
    public string abilityName;
    public int damage;
    [HideInInspector]
    public float speed = 5;
    protected bool limitedUses = false;
    [HideInInspector]
    public int usesLeft = 0;


    public ShooterAbility(Shooter inShooter)
    {
        shooter = inShooter;
    }

	
	void Update () 
    {
	
	}


    // Returns true if ability was cast
    public bool Cast()
    {
        if (checkToCast())
        {
            shooter.loseEnergy(energyCost);
            usesLeft--;
            CastAbility();
            return true;
        }
        else
            return false;
    }


    // Override this method to cast an ability
    protected virtual void CastAbility()
    {

    }


    private bool checkToCast()
    {
        if (limitedUses && usesLeft > 0)
        {
            if (usesLeft > 0)
                return true;
            else
                return false;
        }
        else
            return shooter.canUseAbility(7, energyCost);
    }
}
