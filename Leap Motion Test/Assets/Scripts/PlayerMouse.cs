using UnityEngine;
using System.Collections;

public class PlayerMouse : MonoBehaviour {

    //This script is only used when the player doesn't have Leap Motion Hardware

    Vector3 mousePosition;
    private Player player;

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
            if (transform.position.y < 0.4f)
            {
                transform.position = new Vector3(transform.position.x, 0.4f, transform.position.z);
            }
            if (transform.position.y > 3.65f)
            {
                transform.position = new Vector3(transform.position.x, 3.65f, transform.position.z);
            }
            if (transform.position.x < -3.9f)
            {
                transform.position = new Vector3(-3.9f, transform.position.y, transform.position.z);
            }
            if (transform.position.x > 3.9f)
            {
                transform.position = new Vector3(3.9f, transform.position.y, transform.position.z);
            }
        }
    }
}
