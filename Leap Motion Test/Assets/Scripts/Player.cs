using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private float lives = 1;
    private Animator animator;
    private float timer = 0;
    private Text timerText;
    private float xScale = 0;
    private float yScale = 0;
    private int interval = 10;
    private GameObject cameraObject;
    private GameObject balloon;
    private ParticleSystem hitParticle;
    private Shake shake;
    private AudioSource hitSound;
    private BoxCollider boxCollider;
    private PhpSender phpSender;

    void Start()
    {
        phpSender = GameObject.Find("Nameholder").GetComponent<PhpSender>();
        boxCollider = GetComponent<BoxCollider>();
        hitSound = GetComponent<AudioSource>();
        shake = GameObject.Find("Main Camera").GetComponent<Shake>();
        hitParticle = GetComponentInChildren<ParticleSystem>();
        balloon = GameObject.Find("Balloon");
        balloon.transform.position = transform.position;
        cameraObject = GameObject.Find("Main Camera");
        animator = GetComponent<Animator>();
    }

    //Live getter
    public float livesGetter()
    {
        return lives;
    }

    void Update()
    {
        float tempY = transform.position.y;
        //When you are dead
        if (lives <= 0)
        {
            hitParticle.Play();
            cameraObject.transform.rotation = Quaternion.Euler(20, 180, 0);
            //Shake screen
            shake.MakeShake();
            //Make player fall to the ground
            tempY -= 0.015f;
            animator.SetBool("isDead", true);
            transform.position = new Vector3(transform.position.x, tempY, transform.position.z);
            Invoke("loadLevel", 2f);
        }
    }

    //Once the player crashes into a tree
    void OnCollisionEnter(Collision collision)
    {
        boxCollider.enabled = false;
        phpSender.startSendingProcess();
        hitSound.Play();
        lives--;
    }

    //Show leaderboards
    void loadLevel()
    {
        Application.LoadLevel("Endscreen");
    }
}
