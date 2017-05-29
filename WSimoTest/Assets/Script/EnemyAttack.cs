using UnityEngine;
using System.Collections;


public class EnemyAttack : MonoBehaviour
{
	public float timeBetweenAttacks = 0.5f;     
	public int attackDamage = 10;
	public float health = 100.0f;
	public float damage = 35.0f;
	public bool isdead = false;
	public int score;
	public GameObject navigation;

	Animator anim;                             
	GameObject player;                          
	PlayerHealth playerHealth;
	bool playerInRange;
	float timer;
	float deathtimer = 0.0f;
	float deathtimermax = 1.8f;


	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		anim = GetComponent <Animator> ();
		score = 0;
	}


	void OnTriggerEnter (Collider other)
	{		
		if(other.gameObject == player)
		{
			playerInRange = true;
			Debug.Log ("Contatto!");
		}
		if(other.gameObject.tag.Equals("Weapon"))
			TakeDamage ();
		
	}


	void OnTriggerExit (Collider other)
	{
		
		if(other.gameObject == player)
		{			
			playerInRange = false;
		}
	}


	void Update ()
	{		
		timer += Time.deltaTime;

		if (isdead) {
			deathtimer += Time.deltaTime;
		}

		Debug.Log ("PIR: " + playerInRange);
		anim.SetBool ("pir", playerInRange);

		if(timer >= timeBetweenAttacks && playerInRange)
		{				
			Attack ();
		}

		if (deathtimer >= deathtimermax) 
		{
			Destroy (gameObject);
			Debug.Log ("Destroied!");
		}
	}

	public void TakeDamage()
	{			
		health -= damage;
		Debug.Log ("Zombie health: " + health);

		if (health > 0) 
		{
			score = 5;
			return;
		}
		else
		{
			score = 10;
			isdead = true;
			anim.SetTrigger ("isdead");
			//GetComponent<NavMeshAgent> ().setactive (false);
			return;
		}

	}


	void Attack ()
	{		
		timer = 0f;
		if(playerHealth.currentHealth > 0)
		{				
			playerHealth.TakeDamage (attackDamage);
		}
	}

	void OnColliderEnter (Collision collision)
	{
		
	}
}