using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

    private DistanceCounter distanceCounter;
    private TextMesh distanceText;

    // Use this for initialization
    void Start () {
        distanceCounter = GameObject.Find("DistanceCounter").GetComponent<DistanceCounter>();
        distanceText = GameObject.Find("DistanceFloatText").GetComponent<TextMesh>();
    }
	
	// Update is called once per frame
	void Update () {
        //Display Text
        distanceText.text = distanceCounter.scoreGetter() + " M";
    }
}
