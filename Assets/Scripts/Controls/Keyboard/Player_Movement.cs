using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {
    private float speed = 3.0f;
    public float gravity = -9.8f;

    public static bool inDecision = false;

    private CharacterController _charCont;



    private Vector3 targetPosition;
    private Quaternion targetRotation;

	// Use this for initialization
	void Start () {
        _charCont = GetComponent<CharacterController>();

	}
	
	// Update is called once per frame
	void Update () {

            checkMove();

        
	}

    private void checkMove()
    {
        if (!inDecision)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 6;
            }
            else
            {
                speed = 3;
            }

            float deltaX = Input.GetAxis("Horizontal") * speed;
            float deltaZ = Input.GetAxis("Vertical") * speed;

            Vector3 movement = new Vector3(deltaX, 0, deltaZ);
            movement = Vector3.ClampMagnitude(movement, speed);
            //if (movement != Vector3.zero)
            //    transform.forward = movement;
            movement.y = gravity;
            movement *= Time.deltaTime;
            movement = transform.TransformDirection(movement);
            _charCont.Move(movement);
        }
    }
}
