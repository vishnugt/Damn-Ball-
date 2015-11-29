using UnityEngine;
using System.Collections;

public class Rotate_coin : MonoBehaviour {

	public int rotateSpeed = 50;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		transform.Rotate (Vector3.up * rotateSpeed * Time.fixedDeltaTime);
	
	}
}
