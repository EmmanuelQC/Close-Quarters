using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

	public const int MaxHealth = 200;
	public int CurrentHealth = MaxHealth;
    
	public void TakeDamage(int amount)
	{
		CurrentHealth -= amount;
		if (CurrentHealth <= 0) {
			CurrentHealth = 0;
			gameObject.SetActive (false);

		}

	}
}
