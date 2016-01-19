using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    private Text text;
    private string name;

	void Start () {
        GameObject.Find("PlaceholderText").GetComponent<Text>().enabled = false;
        GameObject.Find("NameField").GetComponent<Image>().enabled = false;
        text = GameObject.Find("NameText").GetComponent<Text>();
        text.enabled = false;
        //Don't destroy the object so we can keep the name for the leaderboards
        DontDestroyOnLoad(transform.gameObject);
    }
	
    //Set name to what has been in the input field
	void Update () {
        name = text.text;
    }

    //Name Getter
    public string nameGetter()
    {
        return name;
    }

    //Show the name field once player presses start
    public void showNameField()
    {
        GameObject.Find("NameField").GetComponent<Image>().enabled = true;
        GameObject.Find("PlaceholderText").GetComponent<Text>().enabled = true;
        text.enabled = true;
    }

    //Play the game
    public void startGame()
    {
        Application.LoadLevel("Main");
    }
}
