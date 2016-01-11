using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawning : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float tempFloat;
    private int Turn;

    private GameObject chunk1;
    private GameObject chunk2;
    private GameObject chunk3;
    private GameObject chunk4;

    private List<GameObject> chunks;

    private Transform prefab;

    void Start()
    {
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
        Turn = Random.Range(0, 3);
        Debug.Log(chunks[Turn]);
        //Load();
        Instantiate(chunks[Turn], new Vector3(0, 0f, -10f), chunks[Turn].transform.rotation);
    }
}