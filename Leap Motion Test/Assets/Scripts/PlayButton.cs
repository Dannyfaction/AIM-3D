using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayButton : MonoBehaviour {

    private Image playGameImage;

	// Use this for initialization
	void Start () {
        playGameImage = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseEnter()
    {
        Debug.Log("Test");
    }
}
