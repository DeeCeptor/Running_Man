using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    public int cameraDistance = -20;
    [HideInInspector]
    public float scroll = 0;
    public float scrollrate;
    private GameObject player;
    private GameObject playerRenderer;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Runner");
        scroll = player.transform.position.x;

        playerRenderer = GameObject.Find("RunningManMesh");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        scroll += scrollrate;
        transform.position = new Vector3(scroll,player.transform.position.y + 5,cameraDistance);


        Vector3 playerPosScreen;
        // Check if the player's ship is on screen.        
        playerPosScreen = Camera.main.WorldToScreenPoint(player.transform.position);
        if (playerPosScreen.x > Screen.width)
        {
            playerPosScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, playerPosScreen.y, 0));
            playerPosScreen.z = 0;
            player.transform.position = playerPosScreen;
        }
        else if (playerPosScreen.x < 0)
        {
            playerPosScreen = Camera.main.ScreenToWorldPoint(new Vector3(10, playerPosScreen.y, 0));
            playerPosScreen.z = 0;
            player.transform.position = playerPosScreen;
        }
	}
}
