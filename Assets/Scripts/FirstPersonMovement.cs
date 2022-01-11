using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstPersonMovement : MonoBehaviour
{
	public const int maxHealth = 100;
	public int currentHealth = maxHealth;
	public RectTransform HealthBar;
	public GameObject gameOverUI;
	//public Transform playerBody;
	
    
	//Material SkinMaterial;
	//Color OriginalColor;
    
	public Text losetext;

	// Update is called once per frame
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("PickUp")) 
		{
			other.gameObject.SetActive (false);
			AddHealth ();
		}
	}

	public void TakeDamage(int amount)
	{
		//SkinMaterial.color = Color.red;
		Debug.Log("Boom");
		AudioSource HitSound = GetComponent<AudioSource> ();
		HitSound.Play ();

		currentHealth -= amount;
		if (currentHealth <= 0 || currentHealth == 0) 
		{
			currentHealth = 0;
			Debug.Log ("Player1 is Dead");
			Destroy (gameObject);
            
			losetext.text = "You Got Blown Up!";
            
			gameOverUI.SetActive (true);
			//Respawn ();
		}
	
		HealthBar.sizeDelta = new Vector2 (currentHealth * 2, HealthBar.sizeDelta.y);

		//SkinMaterial.color  = OriginalColor;
    }

	void AddHealth()
	{
		currentHealth += 20;
			if (currentHealth >= 80) 
			{
				currentHealth = 100;
			}
		HealthBar.sizeDelta = new Vector2 (currentHealth * 2, HealthBar.sizeDelta.y);
	}
		
}
