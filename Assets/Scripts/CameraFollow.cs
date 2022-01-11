using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    Camera camera;
    private Vector3 moveDirection = Vector3.zero;

    public float fowardSpeed = 100f;
    public float turnspeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        moveDirection = new Vector3(Input.GetAxis("Horizontal(AD)"), 0.0f, Input.GetAxis("Vertical(WS)"));
        moveDirection *= fowardSpeed;

        //Rotate
        if (Input.GetKey("q"))
        {
            transform.Rotate(Vector3.up, -turnspeed * Time.deltaTime);
        }

        if (Input.GetKey("e"))
        {
            transform.Rotate(Vector3.up, turnspeed * Time.deltaTime);
        }

        //Camera.Move(moveDirection * Time.deltaTime);
    }
}
