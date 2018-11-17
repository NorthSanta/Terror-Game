using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{

    private CapsuleCollider col;
    public static bool crouching;
    // Use this for initialization
    void Start()
    {
        col = GetComponent<CapsuleCollider>();
        crouching = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyBindings.keys["Crouch"]))
        {
            
            if (col.height > 1)
            {
                col.height -= 0.1f;
            }else if(col.height <= 1 && !crouching)
            {
                crouching = true;
                RigidBodyCharacter.Speed /= 2f;
            }
        }
        else
        {
            if (col.height < 2)
            {
                col.height += 0.1f;
            }
            else if(crouching && col.height == 2)
            {
                crouching = false;
                RigidBodyCharacter.Speed *= 2f;
            }
        }
    }

}
