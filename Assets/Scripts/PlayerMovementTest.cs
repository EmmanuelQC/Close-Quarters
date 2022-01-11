using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTest : MonoBehaviour
{
    
    public Rigidbody rigidbody;
    
    public float fowardSpeed = 100f;
    public float turnspeed = 100f;

    // Update is called once per frame
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update () {
        //movement
        float moveHorizontal = Input.GetAxis("Horizontal(AD)");
        
        float moveVertical = Input.GetAxis ("Vertical(WS)");
        
            if (Input.GetKey ("q")) {
            transform.Rotate (Vector3.up, -turnspeed * Time.deltaTime);
        }

        if (Input.GetKey ("e")) {
            transform.Rotate (Vector3.up, turnspeed * Time.deltaTime);
        }
        
        Vector3 movement = new Vector3 (moveHorizontal, moveVertical);
        
        rigidbody.AddForce (movement * fowardSpeed);
    }
}
