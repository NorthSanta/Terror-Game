using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : Interactable {
    public GameObject Event;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Interact()
    {
        
        Player_Movement.inDecision = false;
        Event.GetComponent<BoxCollider>().enabled = false;
    }
}
