using UnityEngine;
using System.Collections;

public class ExplosiveCountdown : MonoBehaviour {

    [HideInInspector]
    public float countdownTime = 1.5f;
    [HideInInspector]
    public float blastRadius = 9f;
    [HideInInspector]
    public float damage = 100f;
    GameObject runner;

	// Use this for initialization
	void Start () 
    {
        runner = GameObject.Find("Runner");
	}
	
	// Update is called once per frame
	void Update () 
    {
        countdownTime -= Time.deltaTime;

        // Check if we should explode
        if (countdownTime <= 0)
        {
            Debug.Log("Boom");

            Vector2 dirOfPlayer = runner.transform.position = this.transform.position;

            RaycastHit2D hits = Physics2D.Raycast(this.transform.position, dirOfPlayer, blastRadius);
            if (hits != null && hits.transform.gameObject.tag == "Runner")
            {
                hits.transform.gameObject.SendMessage("TakeHit", damage);
                Debug.Log("Hit player");
            }

            Destroy(this.gameObject);
        }
	}
}
