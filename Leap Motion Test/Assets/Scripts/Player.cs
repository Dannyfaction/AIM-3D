using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private float lives = 4;
    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}

    public float livesGetter()
    {
        return lives;
    }
	
	// Update is called once per frame
	void Update () {
        float tempY = transform.position.y;
        if (lives <= 0)
        {
            tempY -= 0.025f;
            animator.SetBool("isDead", true);
            transform.position = new Vector3(transform.position.x,tempY,transform.position.z);
        }
        /*
        if (Input.GetKeyDown("space"))
        {
            lives--;
        }
        */
    }
}
