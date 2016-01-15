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
        DontDestroyOnLoad(transform.gameObject);
    }
	
	void Update () {
        name = text.text;
    }

    public string nameGetter()
    {
        return name;
    }

    public void showNameField()
    {
        GameObject.Find("NameField").GetComponent<Image>().enabled = true;
        GameObject.Find("PlaceholderText").GetComponent<Text>().enabled = true;
        text.enabled = true;
    }

    public void startGame()
    {
        Application.LoadLevel("Main");
    }
}
