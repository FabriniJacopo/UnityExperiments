using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public int startingHealth = 100;   
	public int medkitHealValue = 20;
	public int currentHealth;                                   
	public Slider healthSlider;                                 
	Animator anim;                                       


	void Awake ()
	{
		//healthSlider = GameObject.FindGameObjectWithTag ("Slider");
		currentHealth = startingHealth;
//		healthSlider.value = currentHealth;
	}


	void Update ()
	{
		
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "MedKit") 
		{
			//Debug.Log("MedKit preso!");
			int updatedHealth = currentHealth + medkitHealValue;

			Debug.Log("Salute: "+updatedHealth);
			if (updatedHealth >= 100) 
			{
				currentHealth = 100;
			} 
			else 
			{
				currentHealth = updatedHealth;
			}
			Destroy(col.gameObject);

			healthSlider.value = currentHealth;
		}
	}


	public void TakeDamage (int amount)
	{
		currentHealth -= amount;
		Debug.Log ("currentHealth: " + currentHealth);

		//healthSlider.value = currentHealth;


	}
		     
}