using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawning_Sides : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float right;
    private float tempFloat;
    private int Turn;

    private GameObject sideR1;
    private GameObject sideR2;

    private List<GameObject> chunks;

    private Transform prefab;

    void Start()
    {
        sideR1 = Resources.Load<GameObject>("SideRight1");
        sideR2 = Resources.Load<GameObject>("SideRight2");
        chunks = new List<GameObject>();

        chunks.Add(sideR1);
        chunks.Add(sideR2);

        tempFloat = transform.position.z;
    }

    void FixedUpdate()
    {
        MoveDown();
        if (transform.position.z > 40f)
        {
            SpawnNew();
            Destroy(gameObject);
        }
    }

    private void MoveDown()
    {
        tempFloat += (Time.deltaTime * speed);
        transform.position = new Vector3(transform.position.x, transform.position.y, tempFloat);
    }

    private void SpawnNew()
    {
        Turn = Random.Range(0, 1);
        Instantiate(chunks[Turn], new Vector3(0, 0, -10f), chunks[Turn].transform.rotation);
    }
}