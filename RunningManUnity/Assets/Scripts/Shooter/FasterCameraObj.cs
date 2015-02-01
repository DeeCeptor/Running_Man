using UnityEngine;
using System.Collections;

public class FasterCameraObj : MonoBehaviour 
{
    CameraControl camera;
    float timeRemaining = 7.0f;
    float increase = 0.05f;
    float prevAmount;

	
	void Start () 
    {
        camera = GameObject.Find("Main Camera").GetComponent<CameraControl>();
        Debug.Log(camera.scrollrate);
        prevAmount = camera.scrollrate;
        camera.scrollrate += increase;
	}
	
	
	void Update () 
    {
        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            camera.scrollrate -= increase;
            Destroy(this.gameObject);
        }
	}
}
