using UnityEngine;
using System.Collections;

public class PlayerMouse : MonoBehaviour {

    Vector3 mousePosition;
    private Player player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = 2;
	    mousePosition = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        if (player.livesGetter() > 0)
        {
            transform.position = mousePosition;
        }

        //Player Boundaries
        if (transform.position.y < 0.2f)
        {
            transform.position = new Vector3(transform.position.x, 0.2f, transform.position.z);
        }
        if (transform.position.y > 4f)
        {
            transform.position = new Vector3(transform.position.x, 4f, transform.position.z);
        }
        if (transform.position.x < -4.5f)
        {
            transform.position = new Vector3(-4.5f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 4.5f)
        {
            transform.position = new Vector3(4.5f, transform.position.y, transform.position.z);
        }
    }
}
