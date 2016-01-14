using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawning : MonoBehaviour
{
    private DistanceCounter distanceCounter;
    private float speed;
    private float tempFloat;
    private int Turn;

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
        chunk1 = Resources.Load<GameObject>("Chunk1");
        chunk2 = Resources.Load<GameObject>("Chunk2");
        chunk3 = Resources.Load<GameObject>("Chunk3");
        chunk4 = Resources.Load<GameObject>("Chunk4");
        chunk5 = Resources.Load<GameObject>("Chunk5");
        chunk6 = Resources.Load<GameObject>("Chunk6");
        chunks = new List<GameObject>();
        chunks.Add(chunk1);
        chunks.Add(chunk2);
        chunks.Add(chunk3);
        chunks.Add(chunk4);
        chunks.Add(chunk5);
        chunks.Add(chunk6);

        tempFloat = transform.position.z;
    }

    //spawnig new / deleting the old chunks 
    void FixedUpdate()
    {
        speed = distanceCounter.Speed;
        Debug.Log(speed);
        MoveDown();
        if (transform.position.z > 40f)
        {
            SpawnNew();
            Destroy(gameObject);
        }
    }

    //moving the chunks down
    private void MoveDown()
    {
        tempFloat += (Time.deltaTime * speed);
        transform.position = new Vector3(transform.position.x, transform.position.y, tempFloat);
    }

    private void SpawnNew()
    {
        Turn = Random.Range(0, 2);
        //Load();
        Instantiate(chunks[Turn], new Vector3(0, 0f, -20f), chunks[Turn].transform.rotation);
    }
}