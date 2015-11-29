using UnityEngine;
using System.Collections;

public class Player_Move : MonoBehaviour {

	public static bool isPlayerMoving = false;
	public static int PlayerSpeed = 10;


	void FixedUpdate () 
	{
		if(isPlayerMoving)
		gameObject.transform.Translate (Vector3.right * PlayerSpeed * Time.fixedDeltaTime);
	}
}
