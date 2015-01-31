using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    public int cameradistance = -20;
    private Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = new Vector3(0,0,cameradistance);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = GameObject.Find("Runner").transform.position + offset;
	}
}
