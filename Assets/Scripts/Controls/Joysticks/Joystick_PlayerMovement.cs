using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick_PlayerMovement : MonoBehaviour {

    public float speed = 3.0f;
    public float gravity = -9.8f;

    private CharacterController _charCont;



    private Vector3 targetPosition;
    private Quaternion targetRotation;

    // Use this for initialization
    void Start()
    {
        _charCont = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {

            checkMove();
       
        
    }

    private void checkMove()
    {
        if (Input_Manager.L3Button())
        {
            speed = 6f;
        }
        else if (Input_Manager.MainHorizontal() <= 0.1f && Input_Manager.MainVertical() <= 0.1f)
        {
            speed = 3f;
        }


        float J_DeltaX = Input_Manager.MainHorizontal() * speed;
        float J_DeltaZ = Input_Manager.MainVertical() * speed;

        Vector3 movement = new Vector3(J_DeltaX, 0, J_DeltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charCont.Move(movement);
    }


}
