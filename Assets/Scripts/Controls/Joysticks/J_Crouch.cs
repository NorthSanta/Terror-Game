using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_Crouch : MonoBehaviour {

    private CharacterController col;
    // Use this for initialization
    void Start()
    {
        col = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
       
            if (Input_Manager.R3Button())
            {
                if (col.height > 1)
                    col.height -= 0.1f;
            }
            else
            {
                if (col.height < 2)
                    col.height += 0.1f;


            }
        
    }
}
