using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Spawning_Side_Left : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float left;
    private float tempFloat;
    private int Turn;

    private GameObject sideL1;
    private GameObject sideL2;

    private List<GameObject> chunks2;

    private Transform prefab;

    void Start()
    {

        sideL1 = Resources.Load<GameObject>("SideLeft1");
        sideL2 = Resources.Load<GameObject>("SideLeft2");
        chunks2 = new List<GameObject>();

        chunks2.Add(sideL1);
        chunks2.Add(sideL2);

        tempFloat = transform.position.z;
    }

    void FixedUpdate()
    {
        MoveDown();
        if (transform.position.z > 40)
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
        Instantiate(chunks2[Turn], new Vector3(0, 0, -10f), chunks2[Turn].transform.rotation);
    }
}