using UnityEngine;
using System.Collections;

public class PlayerMouse : MonoBehaviour {

    //This script is only used when the player doesn't have Leap Motion Hardware

    Vector3 mousePosition;
    private Player player;

    private const float yBoundMin = 0.4f;
    private const float yBoundMax = 3.65f;
    private const float xBoundMin = -3.9f;
    private const float xBoundMax = 3.9f;

	void Start () {
        player = GameObject.Find("Player").GetComponent<Player>();
	}
	
	void Update () {
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = 2;
        //Set player to mouse position
	    mousePosition = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        if (player.livesGetter() > 0)
        {
            transform.position = mousePosition;

            //Player Boundaries
            if (transform.position.y < yBoundMin)
            {
                transform.position = new Vector3(transform.position.x, yBoundMin, transform.position.z);
            }
            if (transform.position.y > yBoundMax)
            {
                transform.position = new Vector3(transform.position.x, yBoundMax, transform.position.z);
            }
            if (transform.position.x < xBoundMin)
            {
                transform.position = new Vector3(xBoundMin, transform.position.y, transform.position.z);
            }
            if (transform.position.x > xBoundMax)
            {
                transform.position = new Vector3(xBoundMax, transform.position.y, transform.position.z);
            }
        }
    }
}
