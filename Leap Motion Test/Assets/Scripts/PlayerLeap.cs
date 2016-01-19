using UnityEngine;
using System.Collections;

public class PlayerLeap : MonoBehaviour {

    //The script for player movement with the Leap Hardware

    private GameObject leapObject;
    private float rotationLeft = 0;
    private float rotationRight = 0;
    private float rotationSpeed = 5f;
    private float rotationRange = 0.05f;
    private Player player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    void FixedUpdate() {
        transform.Rotate(Vector3.back * rotationRight);
        transform.Rotate(Vector3.forward * rotationLeft);
        leapObject = GameObject.Find("InvisHandObject(Clone)");

        //Check if the hand has been found by the Leap sensor
        if (leapObject != null && player.livesGetter() > 0)
        {
            //Rotate the player once going left/right
            Vector3 newPos = leapObject.transform.position - transform.position;
            newPos.x = Mathf.Round(newPos.x * 100f) / 100f;
            if (newPos.x > rotationRange && transform.rotation.z > -0.3f)
            {
                rotationRight = rotationSpeed;
            }
            else
            {
                rotationRight = 0;
            }
            if (newPos.x < -rotationRange && transform.rotation.z < 0.3f)
            {
                rotationLeft = rotationSpeed;
            }
            else
            {
                rotationLeft = 0;
            }

            //Rotate back to original
            if (newPos.x < rotationRange && newPos.x >= 0f && transform.rotation.z < 0f)
            {
                rotationLeft = rotationSpeed;
            }
            if (newPos.x > -rotationRange && newPos.x <= 0f && transform.rotation.z > 0f)
            {
                rotationRight = rotationSpeed;
            }

            //Set Player object to the invisible Leap Object
            transform.position = leapObject.transform.position;
        }
        else
        {
            //Rotate player to default once Leap can't find a hand
            rotationLeft = 0;
            rotationRight = 0;
            transform.rotation = Quaternion.identity;
        }
        //Player Boundaries
        if (player.livesGetter() > 0)
        {
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