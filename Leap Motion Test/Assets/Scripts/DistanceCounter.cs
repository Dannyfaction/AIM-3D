using UnityEngine;
using System.Collections;

public class DistanceCounter : MonoBehaviour {

    private float spawningSpeed = 3;
    private float distance = -10;
    private TextMesh distanceText;
    private GameObject balloonObject;
    private float interval = 100;
    private float xScale = 0;
    private float yScale = 0;

	// Use this for initialization
	void Start () {
        balloonObject = GameObject.Find("Balloon");
        distanceText = GameObject.Find("DistanceFloatText").GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
        balloonObject.transform.localScale = new Vector3(xScale,yScale,0.08f);
        distanceText.text = distance + " M";

        if (distance == interval)
        {
            xScale = yScale = 0.08f;
            spawningSpeed += 1f;
            Debug.Log(spawningSpeed);
            interval += 100f;
        }
        if (distance == (interval - 70))
        {
            xScale = yScale = 0f;
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        distance += 10;
    }

    public float Speed
    {
        get
        {
            return spawningSpeed;
        }
    }
}