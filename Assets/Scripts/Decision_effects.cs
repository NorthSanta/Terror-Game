using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Decision_effects {

    public static GameObject screamSlider;
	public static void GetChoice(int id)
    {
        switch (id)
        {
            case -1:
                break;
            case 0:
                Scream();
                break;
            case 1:
                Stomp();
                break;
            case 2:
                Struggle();
                break;
            case 3:
                break;
        }
    }

    private static void Scream()
    {
        Assign_Decisions.Scream(screamSlider,true);
    }
    private static void Stomp()
    {
        Assign_Decisions.Stomp(screamSlider, true);
    }
    private static void Struggle()
    {
        Assign_Decisions.Struggle(screamSlider, true);
    }
}
