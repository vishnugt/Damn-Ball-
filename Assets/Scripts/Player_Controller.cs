using UnityEngine;
using System.Collections;

public class Player_Controller : MonoBehaviour {

	public AudioClip jump, death;
	public GameObject MainCamera;

	public static float fuel = 3.5f;
	public float force = 10.0f;
	public bool isGround = true;
	// Use this for initialization
	void Start () {
	
	}

	private IEnumerator FadeOut(Vector3 alphaStart, Vector3 alphaFinish, float time)
	{
		float elapsedTime = 0;
		MainCamera.transform.position = alphaStart;
		
		while (elapsedTime < time)
		{
			MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, alphaFinish, (elapsedTime / time));
			elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
	}
	// Update is called once per frame
	void Update () 
	{


		if (fuel > 3.5f)
			fuel = 3.5f;
		if (fuel < 0.001f)
		{
			//StartCoroutine(functionForWaiting());
			//MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, new Vector3(-8.5f, 4f, -10f), Time.time );
			StartCoroutine(FadeOut(MainCamera.transform.position, new Vector3(-8.5f, 4f, -10f), 3f));
			Camera_FollowPlayer.isPlaying=false;
			Player_Move.isPlayerMoving = false;
		
			GetComponent<AudioSource>().PlayOneShot(death, 1f);
			Player_Collision.playerDies();
			fuel = 3.5f;
		}

			fuel -= 0.001f;
		
		if (Input.GetButton ("Fire1") && fuel >= 0.001f)
		{
			GetComponent<AudioSource>().PlayOneShot(jump, 0.5f);
			GoUp();
			isGround = false;
		} 

		if (Input.GetKeyDown (KeyCode.Escape))
		{
			Application.LoadLevel("Main");
			Player_Controller.fuel = 3.5f;
			Player_Move.isPlayerMoving = false;
			Camera_FollowPlayer.isPlaying = false;
			MainCamera.transform.position = new Vector3(-8.5f, 4f, 10f);
			Player_Collision.coincountdown = 0;
			Data_Management.datamanagement.currentScore = 0;
			Data_Management.datamanagement.LoadData ();
		}

		if (!isGround) 
		{
			fuel -= 0.001f;
		}
	}


	void GoUp()
	{
		fuel = Mathf.MoveTowards (fuel, 0, Time.fixedDeltaTime);
		GetComponent<Rigidbody> ().AddForce (new Vector3 (0, force));
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Ground")
		{
			//fuel += 1.5f;
			isGround = true;
		}

	
	}
}
