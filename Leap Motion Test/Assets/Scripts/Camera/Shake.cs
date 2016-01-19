using UnityEngine;
using System.Collections;

public class Shake : MonoBehaviour
{

    //Position of camera
    public Vector3 originalPos;
    private bool canShake = false;
    public int timer = 0;

    void Update()
    {
        //Shake the screen to the left and right, then back to its original position
        if (canShake)
        {
            //Every frame
            timer++;
            switch (timer)
            {
                case 1: transform.position = new Vector3(originalPos.x+0.15f,originalPos.y,originalPos.z);
                    break;
                case 2: transform.position = new Vector3(originalPos.x, originalPos.y, originalPos.z);
                    break;
                case 3: transform.position = new Vector3(originalPos.x-0.15f, originalPos.y, originalPos.z);
                    break;
                case 4: transform.position = new Vector3(originalPos.x, originalPos.y, originalPos.z);
                    break;
                case 5: transform.position = new Vector3(originalPos.x + 0.15f, originalPos.y, originalPos.z);
                    break;
                case 6: transform.position = new Vector3(originalPos.x, originalPos.y, originalPos.z);
                    break;
                case 7: transform.position = new Vector3(originalPos.x - 0.15f, originalPos.y, originalPos.z);
                    break;
                case 8: transform.position = new Vector3(originalPos.x, originalPos.y, originalPos.z);
                    break;
            }
        }
    }
    
    //Function which is called from other script to activate the shaking
    public void MakeShake()
    {
        originalPos = transform.position;
        canShake = true;
    }
}