using UnityEngine;
using System.Collections;

public class PlayerMouse : MonoBehaviour {

    Vector3 mousePosition;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = 2;
	    mousePosition = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        transform.position = mousePosition;

        //Player Boundaries
        if (transform.position.y < 0.1f)
        {
            transform.position = new Vector3(transform.position.x,0.1f,transform.position.z);
        }
        if (transform.position.y > 2f)
        {
            transform.position = new Vector3(transform.position.x, 2f, transform.position.z);
        }
        if (transform.position.x < -1.7f)
        {
            transform.position = new Vector3(-1.7f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 1.7f)
        {
            transform.position = new Vector3(1.7f, transform.position.y, transform.position.z);
        }
    }
}
