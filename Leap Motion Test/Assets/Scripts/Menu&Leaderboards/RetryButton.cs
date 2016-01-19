using UnityEngine;
using System.Collections;

public class RetryButton : MonoBehaviour {

    //Restart game button
    public void restartGame()
    {
        GameObject.Destroy(GameObject.Find("Nameholder"));
        GameObject.Destroy(GameObject.Find("DistanceCounter"));
        Application.LoadLevel("Menu");
    }
}
