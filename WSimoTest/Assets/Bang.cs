using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bang : MonoBehaviour {

	public Camera cam;
	public float damage = 35.0f;
	public float range = 200.0f;
	public LayerMask mask;
	public int score;
	GameObject enemyhit;
	public GameObject muzzleFlash;
	float shootingTimer;
	float startTimer = 0.1f;
	bool shooting;
	private AudioSource m_AudioSource;
	public AudioClip bang;

	// Use this for initialization
	void Start () {
		score = 0;
		shootingTimer = startTimer;
		shooting = false;
		m_AudioSource = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Fire1")) {
			Shoot ();
		}

		if (shooting == true) {
			shootingTimer -= Time.deltaTime;
			muzzleFlash.SetActive (true);
			m_AudioSource.clip = bang;
			m_AudioSource.Play();
		}

		if (shootingTimer <= 0) {
			shooting = false;
			shootingTimer = startTimer;
			muzzleFlash.SetActive (false);
		}

	}

	void Shoot(){
		RaycastHit _hit;
		shooting = true;
		//Debug.Log ("Shooting!");
		if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, range, mask)) {
			//Abbiamo colpito qualcosa
			_hit.collider.gameObject.GetComponent<EnemyAttack>().TakeDamage();
			score += _hit.collider.gameObject.GetComponent<EnemyAttack>().score;
			//Debug.Log ("Score: " + score);
		}
	}
}
