using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public GameObject scoreUI;
	public GameObject highScoreUI;
	// Use this for initialization
	void Start () {
	
	}

	void Update ()
	{
		if (Data_Management.datamanagement.coinsCollected > Data_Management.datamanagement.highScore)
		
		{
			Data_Management.datamanagement.highScore = Data_Management.datamanagement.currentScore;
	
		}
		scoreUI.GetComponent<Text> ().text = ("Score " + Data_Management.datamanagement.coinsCollected);
		highScoreUI.GetComponent<Text> ().text = ("High Score " + Data_Management.datamanagement.highScore);
	
	}
}
