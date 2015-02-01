using UnityEngine;
using System.Collections;

public class herobuffspawner : MonoBehaviour {
   
    public GameObject Invuln;
    public GameObject healthpack;
    public GameObject shield;
    public GameObject blink;

	// Use this for initialization
    void Start()
    {
        int choice = Random.Range(0, 3);
        switch (choice)
        {
            case 0:
                Instantiate(Invuln, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                break;
            case 1:
                Instantiate(healthpack, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                break;
            case 2:
                Instantiate(shield, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                break;
            case 3:
                Instantiate(blink, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                break;
        }
    }
	
}
