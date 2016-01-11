using UnityEngine;
using System.Collections;
using System;

public class FloorEndless : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float tempFloat;

    void Start()
    {
        tempFloat = transform.position.z;
    }
    
    void FixedUpdate()
    {
        MoveDown();
        if (transform.position.z > 35)
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
        tempFloat = -5f;
    }
}