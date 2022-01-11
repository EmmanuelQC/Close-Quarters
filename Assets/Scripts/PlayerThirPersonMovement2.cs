using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerThirPersonMovement2 : MonoBehaviour
{
    //my bad *third
    public float fowardSpeed = 500f;
    public float sidewaysSpeed = 500f;
    public float turnspeed = 100f;
    public float zRange = 100;

    public const int maxHealth = 100;
    public int currentHealth = maxHealth;
    public RectTransform HealthBar;
    public GameObject gameOverUI;

    public Text losetext;

    void Start()
    {
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
        
        if (Input.GetKey (KeyCode.RightArrow)) {
            transform.position += new Vector3(0.0f, 0.0f, fowardSpeed * Time.deltaTime);
        }
        if (Input.GetKey (KeyCode.LeftArrow)) {
            transform.position -= new Vector3(0.0f, 0.0f, fowardSpeed * Time.deltaTime);
        }
        if (Input.GetKey (KeyCode.DownArrow)) {
            transform.position += new Vector3 (sidewaysSpeed * Time.deltaTime, 0.0f, 0.0f);
        }
        if (Input.GetKey (KeyCode.UpArrow)) {
            transform.position -= new Vector3 (sidewaysSpeed * Time.deltaTime, 0.0f, 0.0f);
        }
        //Rotate
        if (Input.GetKey ("i")) {
            transform.Rotate (Vector3.up, -turnspeed * Time.deltaTime);
        }

        if (Input.GetKey ("p")) {
            transform.Rotate (Vector3.up, turnspeed * Time.deltaTime);
        }
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
