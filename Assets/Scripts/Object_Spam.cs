using UnityEngine;
using System.Collections;

public class Object_Spam : MonoBehaviour {

	public GameObject[] coins;
	public GameObject[] trees;
	public GameObject player;
	public GameObject enemy;
	public GameObject refill;
	public GameObject spike;
	public float coinSpawnTimer = 7.0f;
	public float enemySpawnTimer = 4.0f;	
	public float treeSpawnTimer = 0.5f;
	public float refillSpawnTimer = 0.1f;
	public float spikeSpawnTimer = 0.2f;
	// Use this for initialization
	void Start () {

		for (int i=-30; i<50;i=i+2	) 
		{
			GameObject tree =Instantiate (trees [Random.Range (0, trees.Length)], new Vector3 (i, 0, Random.Range (3, 22)), Quaternion.Euler (transform.rotation.x, Random.Range(0, 360), transform.rotation.z)) as GameObject;		
			tree.transform.localScale = new Vector3 (Random.Range (0.8f, 1.3f), Random.Range (0.7f, 1.3f), Random.Range (0.7f, 1.3f));
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
		coinSpawnTimer -= Time.deltaTime;
		enemySpawnTimer -= Time.deltaTime;
		treeSpawnTimer -= Time.deltaTime;
		refillSpawnTimer -= Time.deltaTime;
		spikeSpawnTimer -= Time.deltaTime;

		if (coinSpawnTimer < 0.01f) 
		{
			spawnCoins();
		}

		if (enemySpawnTimer < 0.01f) 
		{
			spawnEnemy();
		}

		if (treeSpawnTimer < 0.01f) 
		{
			spawnTrees();
		}
		if (refillSpawnTimer < 0.01f) 
		{
			spawnRefill();
		}
		if (spikeSpawnTimer < 0.01f) 
		{
			spawnSpike();
		}
	}

	void spawnCoins()
	{
		Instantiate (coins [Random.Range (0, coins.Length)], new Vector3 (player.transform.position.x + 30.0f, Random.Range(2, 8), 0), Quaternion.identity);
		coinSpawnTimer = Random.Range (1.0f, 1.85f);
	}

	void spawnEnemy()
	{
		enemy.transform.localScale = new Vector3 (Random.Range (1, 3), Random.Range (1, 3), Random.Range (1, 3));
		Instantiate (enemy, new Vector3 (player.transform.position.x + 50, Random.Range (1, 9), 0), Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
		enemySpawnTimer = Random.Range (1.0f, 2.5f);
	}

	void spawnTrees()
	{
		GameObject tree =Instantiate (trees [Random.Range (0, trees.Length)], new Vector3 (player.transform.position.x + 50, 0, Random.Range (3, 22)), Quaternion.Euler (transform.rotation.x, Random.Range(0, 360), transform.rotation.z)) as GameObject;		
		tree.transform.localScale = new Vector3 (Random.Range (0.8f, 1.3f), Random.Range (0.7f, 1.3f), Random.Range (0.7f, 1.3f));
		treeSpawnTimer = Random.Range(0f, 0.5f);
	}


	void spawnRefill()
		
	{ 
		int constanttime = 10;
		Instantiate(refill, new Vector3(player.transform.position.x + 30, 0,0), Quaternion.identity);
		constanttime += 5;
		refillSpawnTimer = constanttime;	

	}
	void spawnSpike()
	{
		Instantiate(spike, new Vector3(player.transform.position.x + 60, 0,0), Quaternion.identity);
		spikeSpawnTimer =  Random.Range (1.0f, 2.5f);
	}
}
