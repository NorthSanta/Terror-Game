using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int FemaleSurvival;
    public static int MaleSurvival;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Player 0 = Female; Player 1 = Male; feedback false = no feedback
    void increaseSurvival(int player, int increase, bool feedback)
    {
        if (player == 0 )
        {
            FemaleSurvival += increase;
            if (feedback)
            {
                //Show X text in the screen (HAHANOT)
            }
        }
        else if (player == 1)
        {
            MaleSurvival += increase;
            if (feedback)
            {
                //Show X text in the screen (HAHANOT)
            }
        }
    }
}
