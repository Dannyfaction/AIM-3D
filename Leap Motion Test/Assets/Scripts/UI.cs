﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	//Made by Danny Kruiswijk

	private GameObject imageObject;
	private List<string> imageName;
	private int imageNum = 0;
	private Text waveText;
	private Score score;
	private GameObject scoreObject;
    private Text priceText;
    private int price = 100;
    private Text pauzeText;

    void Start () {
        pauzeText = GameObject.Find("PauzeText").GetComponent<Text>();
        scoreObject = GameObject.Find ("Main Camera");
        priceText = GameObject.Find("PriceText").GetComponent<Text>();
        waveText = GameObject.Find("WaveText").GetComponent<Text>();
        score = scoreObject.GetComponent<Score> ();
		imageObject = GameObject.Find ("CanvasTurretImage");
		imageName = new List<string>();
		imageName.Add ("Squirrel_Img");
		imageName.Add ("beer_character");
		imageName.Add ("Moose_af");
	}

	public void LoadNextPic(bool LeftRight)
	{
		imageNum ++;
		if (imageNum > imageName.Count - 1){
			imageNum = 0;
		}
        //Set the price
        switch (imageNum)
        {
            case 0:
                price = 100;
                break;
            case 1:
                price = 150;
                break;
            case 2:
                price = 200;
                break;
        }
		string tempName = imageName[imageNum];
		Sprite mySprite =  Resources.Load <Sprite>(tempName);
		imageObject.GetComponent<SpriteRenderer>().sprite = mySprite;
	}

    //Set Text
	void Update () {
		waveText.text = "Wave: " + score.scoreGetter ();
        priceText.text = "Price  " + price;
	}

	//Sound on/off button
	public void soundButton(){
		if (AudioListener.volume == 1) {
			AudioListener.volume = 0;
		} else {
			AudioListener.volume = 1;
		}
	}

    public void pauzeButton()
    {
        if (Time.timeScale == 1.0f)
        {
            Time.timeScale = 0.0f;
            pauzeText.text = ">";
        }
        else
        {
            if (Time.timeScale == 0.0f)
            {
                Time.timeScale = 1.0f;
                pauzeText.text = "| |";
            }
        }
    }
}