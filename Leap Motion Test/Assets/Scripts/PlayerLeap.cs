using UnityEngine;
using System.Collections;

public class PlayerLeap : MonoBehaviour {

    private GameObject leapObject;
    private float rotationValueLeft = 0;
    private float rotationValueRight = 0;

	void Start () {
	
	}
	
	void Update () {
        //Transform Rotation Back = Rechts
        //Transform Rotation Forward = Links
        transform.Rotate(Vector3.back * rotationValueRight);
        transform.Rotate(Vector3.forward * rotationValueLeft);
        leapObject = GameObject.Find("InvisHandObject(Clone)");
        /*
        if (leapObject.transform.position.x < transform.position.x)
        {
            rotationValueLeft = 1;
        }
        else
        {
            rotationValueLeft = 0;
        }
        if (leapObject.transform.position.x > transform.position.x)
        {
            rotationValueRight = 0;
        }
        else
        {
            rotationValueRight = 0;
        }
        */
        if (leapObject != null)
        {
            transform.position = leapObject.transform.position;
        }
        //Player Boundaries
        if (transform.position.y < 0.1f)
        {
            transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);
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