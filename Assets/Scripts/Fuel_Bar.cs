using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fuel_Bar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		fuelbarUpdate ();
	
	}

	void fuelbarUpdate()
	{
		if (Player_Controller.fuel > 0.001) 
		{
			gameObject.transform.localScale =  new Vector3(Player_Controller.fuel, gameObject.transform.localScale.y, gameObject.transform.localScale.z);		
		}
	}
}
