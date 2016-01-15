using UnityEngine;
using System.Collections;

public class HillEndless : MonoBehaviour {

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
        speed = distanceCounter.Speed;
        MoveDown();
        if (transform.position.z > 35f)
        {
            MoveUp();
        }
    }

    private void MoveDown()
    {
        tempFloat += (Time.deltaTime * speed);
        transform.position = new Vector3(transform.position.x, transform.position.y, tempFloat);
    }

    private void MoveUp()
    {
        tempFloat = -15f;
    }
}






