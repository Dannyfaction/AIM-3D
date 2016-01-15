using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PhpSender : MonoBehaviour {

	//Made By Danny Kruiswijk

	private DistanceCounter scoreKeeper;
	private List<string> scorelist = new List<string>();
	private int tempScore;
	private Menu sender;
	private string tempName;
	private GameObject nameObject;
	
	void Awake () {
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
        string scorestring = (tempName + "," + tempScore.ToString());
		WWWForm score = new WWWForm();
		score.AddField("score", scorestring);
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