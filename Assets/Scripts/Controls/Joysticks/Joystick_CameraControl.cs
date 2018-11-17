using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick_CameraControl : MonoBehaviour {

    // Use this for initialization
    public enum RotationAxis
    {
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxis axes = RotationAxis.MouseX;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    public float sensHorizontal = 10.0f;
    public float sensVertical = 10.0f;

    private float _rotationX = 0;

   
    private static Quaternion targetRotation;
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
       
       
            checkRot();
       
    }

    private void checkRot()
    {
        if (axes == RotationAxis.MouseX)
        {
            transform.Rotate(0, Input_Manager.SecondaryHorizontal() * sensHorizontal, 0);
        }
        else if (axes == RotationAxis.MouseY)
        {
            _rotationX -= Input_Manager.SecondaryVertical() * sensVertical;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }

  
}

