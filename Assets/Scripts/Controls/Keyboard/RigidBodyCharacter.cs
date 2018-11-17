using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyCharacter : MonoBehaviour
{
    
    public static float Speed = 2f;
    [SerializeField]
    private bool sprinting;

    private Rigidbody _body;
    private Vector3 _inputs = Vector3.zero;

    void Start()
    {
        _body = GetComponent<Rigidbody>();
        sprinting = false;
    }

    void Update()
    {
        if (!Camera_Control.paused)
        {
            if (Input.GetKey(KeyBindings.keys["Sprint"]) && !Crouch.crouching && !sprinting)
            {
                sprinting = true;
                Speed *= 1.5f;
            }
            else if (Input.GetKeyUp(KeyBindings.keys["Sprint"]) && !Crouch.crouching && sprinting)
            {
                sprinting = false;
                Speed = 3f;
            }


            _inputs = Vector3.zero;
            _inputs.x = Input.GetAxis("Horizontal");
            _inputs.z = Input.GetAxis("Vertical");
        }
        
    }


    void FixedUpdate()
    {
        if (!Camera_Control.paused)
        {
            _inputs = transform.TransformDirection(_inputs);
            _body.MovePosition(_body.position + _inputs * Speed * Time.fixedDeltaTime);
        }
    }
}
