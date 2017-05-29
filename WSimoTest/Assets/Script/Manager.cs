using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

	public int score;
	GameObject player;
	GameObject hud;
	GameObject textscore;
	public GameObject enemy;
	int i = 0;
	float spawntime = 30.0f;
	//numero ondata
	int n = 1;
	//lista per contenere posizioni dei medkit generate random e numero spawnpoint
	public GameObject MedKit;
	List<Vector3> medKitPossiblePositions = new List<Vector3> ();
	int numberOfMedKitSpawnPoints = 10;
	float spawnMedKitTime = 10.0f;

	// Use this for initialization
	void Start () {
		score = 0;
		player = GameObject.Find ("FPSController");
		hud = GameObject.Find ("HUD");
		n = 1;
		GenerateMedKitPosition ();
		StartCoroutine(SpawnWaves());
		StartCoroutine (SpawnMedKits ());
	}
	
	// Update is called once per frame
	void Update () {		

		score = player.GetComponentInChildren<Bang>().score;
		//Debug.Log ("Score: " + score);

		hud.transform.GetChild (2).gameObject.GetComponent<Text> ().text = "Score: " + score;
	}

	IEnumerator SpawnWaves()
	{
		while(true){
			for (i = 0; i < 1*n; i++) 
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-90, -75), -95, Random.Range (31, 48));
				Instantiate (enemy, spawnPosition, enemy.transform.rotation);	
			}

			for (i = 0; i < 1*n; i++) 
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-36, -48), -95, Random.Range (60, 70));
				Instantiate (enemy, spawnPosition, enemy.transform.rotation);	
			}

			for (i = 0; i < 1*n; i++) 
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (51, 65), -95, Random.Range (30, 50));
				Instantiate (enemy, spawnPosition, enemy.transform.rotation);	
			}

			n++;
			yield return new WaitForSeconds (spawntime);
			Debug.Log ("New Wave Incoming!");
		}
	}
	IEnumerator SpawnMedKits()
	{
		while(true)
		{
			int index = Random.Range(0,medKitPossiblePositions.Count);
			Instantiate(MedKit, medKitPossiblePositions[index], MedKit.transform.rotation);
			yield return new WaitForSeconds (spawnMedKitTime);
			Debug.Log ("New MedKit!");
		}
	}
	void GenerateMedKitPosition()
	{
		//angolo strada: x=65 z=62
		//angolo opposto: x=-78 z=75
		for (int k = 0; k < numberOfMedKitSpawnPoints; k++)
		{
			medKitPossiblePositions.Add(new Vector3(Random.Range(-78,65),-98,Random.Range(62,75)));
		}
	}
}
