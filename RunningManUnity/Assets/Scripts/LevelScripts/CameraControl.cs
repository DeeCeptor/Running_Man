using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    public int cameraDistance = -20;
    [HideInInspector]
    public float scroll = 0;
    public float scrollrate;
    private GameObject player;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Runner");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        scroll += scrollrate;
        transform.position = new Vector3(scroll,player.transform.position.y + 5,cameraDistance);
	}
}
