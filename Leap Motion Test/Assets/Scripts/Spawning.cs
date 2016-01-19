using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawning : MonoBehaviour
{
    //Script for spawning and moving chunks up/down

    private DistanceCounter distanceCounter;
    private float speed;
    private float tempFloat;
    private int Turn;

    //All the different chunks
    private GameObject chunk1;
    private GameObject chunk2;
    private GameObject chunk3;
    private GameObject chunk4;
    private GameObject chunk5;
    private GameObject chunk6;
    private GameObject chunk7;

    private List<GameObject> chunks;

    private Transform prefab;
    void Start()
    {
        distanceCounter = GameObject.Find("DistanceCounter").GetComponent<DistanceCounter>();

        //Get the prefab chunks from resource folder
        chunk1 = Resources.Load<GameObject>("Chunk1");
        chunk2 = Resources.Load<GameObject>("Chunk2");
        chunk3 = Resources.Load<GameObject>("Chunk3");
        chunk4 = Resources.Load<GameObject>("Chunk4");
        chunk5 = Resources.Load<GameObject>("Chunk5");
        chunk6 = Resources.Load<GameObject>("Chunk6");
        chunks = new List<GameObject>();

        //Put the chunks into a list
        chunks.Add(chunk1);
        chunks.Add(chunk2);
        chunks.Add(chunk3);
        chunks.Add(chunk4);
        chunks.Add(chunk5);
        chunks.Add(chunk6);

        tempFloat = transform.position.z;
    }

    //Spawnig new / deleting the old chunks 
    void FixedUpdate()
    {
        speed = distanceCounter.Speed;
        MoveDown();
        if (transform.position.z > 40f)
        {
            SpawnNew();
            Destroy(gameObject);
        }
    }

    //Moving the chunks down
    private void MoveDown()
    {
        tempFloat += (Time.deltaTime * speed);
        transform.position = new Vector3(transform.position.x, transform.position.y, tempFloat);
    }

    //Spawn new randomized chunks
    private void SpawnNew()
    {
        Turn = Random.Range(0, 6);
        Instantiate(chunks[Turn], new Vector3(0, 0f, -20f), chunks[Turn].transform.rotation);
    }
}