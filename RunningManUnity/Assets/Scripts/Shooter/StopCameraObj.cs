using UnityEngine;
using System.Collections;

public class StopCameraObj : MonoBehaviour 
{
    CameraControl camera;
    float timeRemaining = 10.0f;
    float prevAmount;

	// Use this for initialization
	void Start () 
    {
        camera = Camera.main.GetComponent<CameraControl>();
        prevAmount = camera.scrollrate;
        camera.scrollrate = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            camera.scrollrate += prevAmount;
            Destroy(this.gameObject);
        }
	}
}
