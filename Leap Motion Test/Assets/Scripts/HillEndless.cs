using UnityEngine;
using System.Collections;

public class HillEndless : MonoBehaviour {

    //Script for moving the Hills (On the side) up and down

    [SerializeField]
    private float speed;
    private float tempFloat;

    private DistanceCounter distanceCounter;

    void Start()
    {
        distanceCounter = GameObject.Find("DistanceCounter").GetComponent<DistanceCounter>();
        tempFloat = transform.position.z;
    }

    void FixedUpdate()
    {
        //Speed of the hills get determained by how many meters have been traveled
        speed = distanceCounter.Speed;
        MoveDown();
        //If hills reach certain point, move back up
        if (transform.position.z > 35f)
        {
            MoveUp();
        }
    }

    //Moves the hills down untill certain point
    private void MoveDown()
    {
        tempFloat += (Time.deltaTime * speed);
        transform.position = new Vector3(transform.position.x, transform.position.y, tempFloat);
    }

    //Moves hills back up
    private void MoveUp()
    {
        tempFloat = -15f;
    }
}






