using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Decisions : MonoBehaviour {
    
    public Dictionary<int, string> decisions = new Dictionary<int, string>();
	// Use this for initialization
	private void Start () {
        decisions.Add(-1, "");
        //Puzzle 1
        decisions.Add(0,"Scream");
        decisions.Add(1, "Stomp Floor");
        decisions.Add(2, "Struggle");
        decisions.Add(3, "asd");
        decisions.Add(4, "qwe");
        decisions.Add(5, "ppoio");
        decisions.Add(6, "valette");
    }
}
