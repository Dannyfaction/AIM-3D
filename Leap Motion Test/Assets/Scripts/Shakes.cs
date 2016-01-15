using UnityEngine;
using System.Collections;

public class Shakes : MonoBehaviour
{

    // pakt positie van de camera
    public Transform camTransform;

    // hoe lang de camera gaat shaken
    private float shake = 0f;

    // hoeveel en hoehard de camera gaat shaken
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    // de beginpositie van camera
    Vector3 originalPos;

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    void Update()
    {
        if (shake > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shake -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shake = 0f;
            camTransform.localPosition = originalPos;
        }
    }

    public void MakeShake(){
        shake = 1;
    }
}