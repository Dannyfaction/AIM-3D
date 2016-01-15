using UnityEngine;
using System.Collections;

public class DistanceCounter : MonoBehaviour {

    private float spawningSpeed = 3;
    private int distance = -10;
    private TextMesh distanceText;
    private GameObject balloonObject;
    private float interval = 100;
    private float xScale = 0;
    private float yScale = 0;
    private bool canSpeed = true;
    private Animator animator;

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(transform.gameObject);
        balloonObject = GameObject.Find("Balloon");
        distanceText = GameObject.Find("DistanceFloatText").GetComponent<TextMesh>();
        animator = GameObject.Find("Player").GetComponent<Animator>();
        animator.speed = 0.75f;
    }

    public int scoreGetter()
    {
        return distance;
    }
	
	// Update is called once per frame
	void Update () {
        if (balloonObject != null)
        {
            balloonObject.transform.localScale = new Vector3(xScale, yScale, 0.08f);
            distanceText.text = distance + " M";
        }
        if (distance == interval - 50 && canSpeed == true)
        {
            spawningSpeed += 1f;
            animator.speed += 0.25f;
            canSpeed = false;
        }
        if (distance == interval)
        {
            xScale = yScale = 0.08f;
            canSpeed = true;
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





