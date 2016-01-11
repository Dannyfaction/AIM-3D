using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour {

    private float xValue;
    private float yValue;

    void Start()
    {
        StartCoroutine("ChangeScreen");
    }

    IEnumerator ChangeScreen()
    {
        yield return new WaitForSeconds(3);
        Application.LoadLevel("Menu");
    }

    void Update()
    {
        if (xValue < 1.2f)
        {
            xValue += 0.005f;
            yValue += 0.005f;
        }
        transform.localScale = new Vector2(xValue,yValue);
    }
}
