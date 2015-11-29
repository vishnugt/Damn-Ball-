using UnityEngine;
using System.Collections;

public class Game_Init : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Data_Management.datamanagement.currentScore = 0;
		Data_Management.datamanagement.LoadData ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
