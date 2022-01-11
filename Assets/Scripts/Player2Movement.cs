using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Movement : MonoBehaviour {

    CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    
    public float fowardSpeed = 100f;
	public float turnspeed = 100f;
    public float zRange = 100;

	public const int maxHealth = 100;
	public int currentHealth = maxHealth;
	public RectTransform HealthBar;
	public GameObject gameOverUI;

	public Text losetext;

	void Start()
	{
        characterController = GetComponent<CharacterController>();
        
		gameOverUI.SetActive (false);

		losetext.text = "";
	}
		
	// Update is called once per frame
	void Update () {
		if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        if(transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y, -zRange);
        }
        //movement
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveDirection *= fowardSpeed;
        
		//Rotate
		if (Input.GetKey ("i")) {
			transform.Rotate (Vector3.up, -turnspeed * Time.deltaTime);
		}

		if (Input.GetKey ("p")) {
			transform.Rotate (Vector3.up, turnspeed * Time.deltaTime);
		}
        
        characterController.Move(moveDirection * Time.deltaTime);
	}

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
		AudioSource HitSound = GetComponent<AudioSource> ();
		HitSound.Play ();

		currentHealth -= amount;

		if (currentHealth <= 0) 
		{
			currentHealth = 0;
			Debug.Log ("Player2 is Dead");
			Destroy (gameObject);
			losetext.text = "Player 1 Wins!";

			gameOverUI.SetActive (true);

		}

		HealthBar.sizeDelta = new Vector2 (currentHealth * 2, HealthBar.sizeDelta.y);
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
