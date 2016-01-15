using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawning : MonoBehaviour
{
    private float speed;
    private float tempFloat;
    private int Turn;

    private DistanceCounter distanceCounter;

    private GameObject chunk1;
    private GameObject chunk2;
    private GameObject chunk3;
    private GameObject chunk4;

    private Shakes shake;

    private List<GameObject> chunks;

    private Transform prefab;

    void Start()
    {

        shake = GameObject.Find("Main Camera").GetComponent<Shakes>();

        distanceCounter = new DistanceCounter();
        
        chunk1 = Resources.Load<GameObject>("Chunk1");
        chunk2 = Resources.Load<GameObject>("Chunk2");
        chunk3 = Resources.Load<GameObject>("Chunk3");
        chunk4 = Resources.Load<GameObject>("Chunk4");
        chunks = new List<GameObject>();
        chunks.Add(chunk1);
        chunks.Add(chunk2);
        chunks.Add(chunk3);
        chunks.Add(chunk4);

        tempFloat = transform.position.z;
    }

    //spawn new chunks when hitting the end
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "spawn")
        {
            SpawnNew();
        }
        
    }

    //deleting the old chunks
    void FixedUpdate()
    {
        speed = distanceCounter.Speed;

        MoveDown();
        if (transform.position.z > 50f)
        {
            shake.MakeShake();
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
        Turn = Random.Range(0, 3);
        Debug.Log(chunks[Turn]);
        //Load();
        Instantiate(chunks[Turn], new Vector3(5f, 0f, -10f), chunks[Turn].transform.rotation);

        Turn = Random.Range(0, 3);
        Instantiate(chunks[Turn], new Vector3(-5f, 0f, -10f), chunks[Turn].transform.rotation);
    }
}