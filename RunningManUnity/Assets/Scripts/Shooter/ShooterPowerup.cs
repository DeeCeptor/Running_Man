using UnityEngine;
using System.Collections;

public class ShooterPowerup : MonoBehaviour {
    Shooter shooter;
    ShooterAbility[] potentialAbilities = new ShooterAbility[2];
    ShooterAbility abilityGiven;

	// Use this for initialization
	void Start () {
        shooter = GameObject.Find("Shooter").GetComponent<Shooter>();

	    // Determine what type of powerup this is
        potentialAbilities[0] = new Explosives(shooter);
        potentialAbilities[1] = new ShrapnelBlast(shooter);
        //potentialAbilities[2] = new Explosives(shooter);

        abilityGiven = potentialAbilities[Random.Range(0, potentialAbilities.Length)];
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnMouseDown()
    {
        shooter.changeRightClickAbility(abilityGiven);
        Debug.Log("Shooter got " + abilityGiven.abilityName);
        Destroy(this.gameObject);
    }
}
