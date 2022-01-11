using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerThirdPersonMovement : MonoBehaviour
{
    public float fowardSpeed = 500f;
    public float sidewaysSpeed = 500f;
    public float turnspeed = 100f;
    public float zRange = 100;

    public const int maxHealth = 100;
    public int currentHealth = maxHealth;
    public RectTransform HealthBar;
    public GameObject gameOverUI;

    Material SkinMaterial;
    Color OriginalColor;

    public Text losetext;

    // Update is called once per frame
    void Start()
    {
        losetext.text = "";

        SkinMaterial = GetComponent <Renderer> ().material;
        OriginalColor = SkinMaterial.color;
    }

    void Update () {
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,zRange);
        }
        if(transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y,-zRange);
        }
        //movement
        if (Input.GetKey ("a")) {
            transform.position += new Vector3(0.0f, 0.0f, fowardSpeed * Time.deltaTime);
        }
        if (Input.GetKey ("d")) {
            transform.position -= new Vector3(0.0f, 0.0f,fowardSpeed * Time.deltaTime);
        }
        if (Input.GetKey ("w")) {
            transform.position += new Vector3 (sidewaysSpeed * Time.deltaTime, 0.0f, 0.0f);
        }
        if (Input.GetKey ("s")) {
            transform.position -= new Vector3 (sidewaysSpeed * Time.deltaTime, 0.0f, 0.0f);
        }
        //Rotate
        if (Input.GetKey ("q")) {
            transform.Rotate (Vector3.up, -turnspeed * Time.deltaTime);
        }

        if (Input.GetKey ("e")) {
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
        SkinMaterial.color = Color.red;

        AudioSource HitSound = GetComponent<AudioSource> ();
        HitSound.Play ();

        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log ("Player1 is Dead");
            Destroy (gameObject);

            losetext.text = "Player 2 Wins!";

            gameOverUI.SetActive (true);
            //Respawn ();
        }
    
        HealthBar.sizeDelta = new Vector2 (currentHealth * 2, HealthBar.sizeDelta.y);

        SkinMaterial.color  = OriginalColor;
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
