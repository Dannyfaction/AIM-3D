using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PhpSender : MonoBehaviour {

    //Script for sending the name and score to online databse

	//Made By Danny Kruiswijk

	private DistanceCounter scoreKeeper;
	private List<string> scorelist = new List<string>();
	private int tempScore;
	private Menu sender;
	private string tempName;
	private GameObject nameObject;
	
	void Awake () {
        //Don't destroy this object on scene change so we can still use it in leaderboard screen
		DontDestroyOnLoad (transform.gameObject);
		nameObject = GameObject.Find ("Nameholder");
		sender = nameObject.GetComponent<Menu> ();
	}

	//Puts it in a list
    IEnumerator WaitForRequest(WWW www)
    {
		yield return www;
		foreach(string line in www.text.Split('\n'))
		{
			scorelist.Add(line);
		}
    }

	//Send to PHP script
	public void startSendingProcess()
	{
        tempName = sender.nameGetter();
        scoreKeeper = GameObject.Find("DistanceCounter").GetComponent<DistanceCounter>();
        tempScore = scoreKeeper.scoreGetter ();
        //Puts the name and score into 1 line
        string scorestring = (tempName + "," + tempScore.ToString());
		WWWForm score = new WWWForm();
		score.AddField("score", scorestring);
        //Where the databse is hosted
		WWW w = new WWW("http://19083.hosts.ma-cloud.nl/aim3d/phpscript.php", score);
		StartCoroutine(WaitForRequest(w));
	}

	//Get current score
	public List<string> getCurrentScoreList
	{
		get
		{
			return scorelist;
		}
	}
}