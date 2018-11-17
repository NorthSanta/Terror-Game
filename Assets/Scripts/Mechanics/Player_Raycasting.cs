using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Raycasting : MonoBehaviour {
    public float distanceToSee = 3f;
    RaycastHit hit;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(transform.position, transform.forward * distanceToSee,Color.red);

        if (Physics.Raycast(transform.position,transform.forward,out hit, distanceToSee))
        {
            //Debug.Log("I hit " + hit.transform.name);
            Interactable inter = hit.collider.gameObject.GetComponent<Interactable>();
            if ((Input.GetKeyDown(KeyBindings.keys["Interact"]) || Input_Manager.XButton()) && inter != null) 
            {
                inter.Interact();
            }
        }
	}
}
