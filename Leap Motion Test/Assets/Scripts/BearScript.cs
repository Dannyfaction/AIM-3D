using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BearScript : MonoBehaviour {

    //Made by Danny Kruiswijk

    private float power = 0;
    private float reloadTimer = 0f;
    private GameObject whichEnemy;
    private Collider2D[] hitColliders;
    private Animator animator;
    private AudioSource audioSource;

	void Start () {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        if (transform.name == "Bear(Clone)")
        {
            power = 50;
        }
        else
        {
            power = 100;
        }
    }

	void Update () {
        hitColliders = Physics2D.OverlapCircleAll(transform.position, 1f,1);
        if (reloadTimer != 0)
        {
            reloadTimer--;
        }
        if (hitColliders.Length > 0)
        {
            whichEnemy = hitColliders[hitColliders.Length - 1].gameObject;
            if (whichEnemy.transform.position.x < transform.position.x)
            {
                if (transform.name == "Bear(Clone)")
                {
                    transform.localScale = new Vector3(-0.4f, 0.4f, 1f);
                }
                else
                {
                    transform.localScale = new Vector3(-0.25f, 0.25f, 1f);
                }
            }
            else
            {
                if (transform.name == "Bear(Clone)")
                {
                    transform.localScale = new Vector3(0.4f, 0.4f, 1f);
                }
                else
                {
                    transform.localScale = new Vector3(0.25f, 0.25f, 1f);
                }
            }
            if (hitColliders[0].gameObject.GetComponent<EnemyScript>() != null)
            {
                if (reloadTimer <= 0)
                {
                    //Hit
                    audioSource.Play();
                    animator.SetBool("isAttacking",true);
                    if (transform.name == "Bear(Clone)")
                    {
                        reloadTimer = 80f;
                    }
                    else
                    {
                        reloadTimer = 160f;
                    }
                    EnemyScript enemyScript = whichEnemy.GetComponent<EnemyScript>();
                    float tempFloat = enemyScript.healthGetter();
                    enemyScript.healthSetter(tempFloat - power);
                }
            }
        }
        else
        {
            animator.SetBool("isAttacking",false);
        }

    }
}