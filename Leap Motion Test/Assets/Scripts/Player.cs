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
    private Vector3 playerUIPos;

    // Use this for initialization
    void Start()
    {
        timerText = GameObject.Find("TimerText").GetComponent<Text>();
        animator = GetComponent<Animator>();
    }

    public float livesGetter()
    {
        return lives;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(interval-8);
        timer += Time.deltaTime;
        if ((Mathf.Round(timer * 100f) / 100f) == interval)
        {
            interval += 10;
            xScale = yScale = 0.5f;
        }
        if ((Mathf.Round(timer * 100f) / 100f) == (interval-7))
        {
            xScale = yScale = 0f;
        }
        timerText.transform.localScale = new Vector3(xScale, yScale, 0f);
        //Debug.Log("Seconds: " + (Mathf.Round(timer * 100f) / 100f));
        timerText.text = "Fly Time: " + (Mathf.Round(timer * 100f) / 100f);
        float tempY = transform.position.y;
        if (lives <= 0)
        {
            tempY -= 0.015f;
            animator.SetBool("isDead", true);
            transform.position = new Vector3(transform.position.x, tempY, transform.position.z);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        lives--;
    }
}
