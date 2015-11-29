using UnityEngine;
using System.Collections;

public class Camera_FollowPlayer : MonoBehaviour {

	public static bool isPlaying = false;
	public  GameObject Camera;
	public GameObject player;
	public float cameraSpeed = 2;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void FixedUpdate () {

		if (isPlaying)
		{
			
			Vector3 cameraPosition = transform.position;
			cameraPosition.x = player.transform.position.x - -7.0f;
			transform.position = Vector3.Lerp (transform.position, cameraPosition, cameraSpeed* Time.fixedDeltaTime);
			
			
			cameraPosition.y = player.transform.position.y + 2;
			transform.position = Vector3.Lerp (transform.position, cameraPosition, 7.0f * Time.fixedDeltaTime);
		}
	
	}
}
