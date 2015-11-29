using UnityEngine;
using System.Collections;

public class Player_Collision : MonoBehaviour {
	
	
	public AudioClip coinCollect, jump, death, refill;
	public GameObject MainCamera;
	public GameObject player;


	public static int coincountdown = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		coincountdown++;
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

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Obstacle") 
		{
			GetComponent<AudioSource>().PlayOneShot(death, 0.8f);
			StartCoroutine(functionForWaiting());
			//MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, new Vector3(-8.5f, 4f, -10f), Time.time );
			StartCoroutine(FadeOut(MainCamera.transform.position, new Vector3(-8.5f, 4f, -10f), 3f));
			Camera_FollowPlayer.isPlaying=false;
			Player_Move.isPlayerMoving = false;
			GetComponent<AudioSource>().PlayOneShot(death, 1f);
			playerDies();

		}
	}

	IEnumerator functionForWaiting()
	{
		yield return new WaitForSeconds (death.length);

	}



	void OnTriggerEnter(Collider col)
	{

		if (col.gameObject.tag == "Coin") 
		
		{
			GetComponent<AudioSource>().PlayOneShot(coinCollect, 1f);
			Player_Controller.fuel += 0.12f;
			Destroy(col.gameObject);
			coincountdown++;
			Data_Management.datamanagement.coinsCollected++;
			Data_Management.datamanagement.currentScore++;
		}
		if (col.gameObject.tag == "Drain") 
		{
			GetComponent<AudioSource>().PlayOneShot(coinCollect, 1f);
			Player_Controller.fuel += 0.12f;
			Destroy(col.gameObject);
			coincountdown++;
			Data_Management.datamanagement.coinsCollected++;
			Data_Management.datamanagement.currentScore++;
		}
		if (col.gameObject.tag == "Refill") 
		{
			GetComponent<AudioSource>().PlayOneShot(refill, 1f);
			Player_Controller.fuel = 2.5f;
			Destroy(col.gameObject);
		}

		if (col.gameObject.tag == "Spike")
		{
			GetComponent<AudioSource>().PlayOneShot(death, 0.8f);
			while(true)
			{
				if(GetComponent<AudioSource>().isPlaying)
				{
				}
				else
				{
					break;
				}

			};
			
			//StartCoroutine(functionForWaiting());
			//MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, new Vector3(-8.5f, 4f, -10f), Time.time );
			StartCoroutine(FadeOut(MainCamera.transform.position, new Vector3(-8.5f, 4f, -10f), 3f));
			Camera_FollowPlayer.isPlaying=false;
			Player_Move.isPlayerMoving = false;
			GetComponent<AudioSource>().PlayOneShot(death, 1f);
			playerDies();
		}

	}



	public static void playerDies()
	{

	}


	public void startGame()
	{
		coincountdown = 0;
		Data_Management.datamanagement.coinsCollected = 0;
		Data_Management.datamanagement.SaveData ();	
		Player_Controller.fuel = 3.5f; 
		Camera_FollowPlayer.isPlaying = true;
		Player_Move.isPlayerMoving = true;
		Application.LoadLevel ("Main");
	}


	public void exitGame()
	{
		Application.Quit ();
	}
}
