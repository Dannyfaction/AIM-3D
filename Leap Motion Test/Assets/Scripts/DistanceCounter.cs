using UnityEngine;
using System.Collections;

public class DistanceCounter : MonoBehaviour {

    private float spawningSpeed = 3;
    private int distance = -10;
    private TextMesh distanceText;
    private GameObject balloonObject;
    private float interval = 100;
    private float xScale = 0f;
    private float yScale = 0f;
    private bool canSpeed = true;
    private Animator animator;
    private GameObject cameraObject;
    private AudioSource pointSound;

    void Start () {
        DontDestroyOnLoad(transform.gameObject);
        cameraObject = GameObject.Find("Main Camera");
        balloonObject = GameObject.Find("Balloon");
        distanceText = GameObject.Find("DistanceFloatText").GetComponent<TextMesh>();
        animator = GameObject.Find("Player").GetComponent<Animator>();
        pointSound = balloonObject.GetComponent<AudioSource>();
        //Animation of the bird
        animator.speed = 0.75f;
    }

    //Score Getter
    public int scoreGetter()
    {
        return distance;
    }
	
	void Update () {
        //Set Balloon with distance on top of screen
        balloonObject.transform.position = new Vector3(cameraObject.transform.position.x,cameraObject.transform.position.y +0.9f,cameraObject.transform.position.z - 2f);
        if (balloonObject != null)
        {
            balloonObject.transform.localScale = new Vector3(xScale, yScale, 0.08f);
            //Display Text
            distanceText.text = distance + " M";
        }
        //Every 50 meter speed up
        if (distance == interval - 50 && canSpeed == true)
        {
            spawningSpeed += 1f;
            animator.speed += 0.25f;
            canSpeed = false;
        }
        //Every 100 meter show distance counter and play sound
        if (distance == interval)
        {
            xScale = yScale = 0.08f;
            pointSound.Play();
            canSpeed = true;
            interval += 100f;
        }
        //Remove balloon after it ha been shown
        if (distance == (interval - 80))
        {
            xScale = yScale = 0f;
        }
	}

    //This counts the meters
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





