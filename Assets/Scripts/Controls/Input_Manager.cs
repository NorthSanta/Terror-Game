using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Input_Manager {

    public static float MainHorizontal()
    {
        float r = 0.0f;
        r += Input.GetAxis("J_MainHorizontal");
        
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static float MainVertical()
    {
        float r = 0.0f;
        r += Input.GetAxis("J_MainVertical");
        
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static float SecondaryHorizontal()
    {
        float r = 0.0f;
        r += Input.GetAxis("J_SecondaryHorizontal");
        return r;
    }

    public static float SecondaryVertical()
    {
        float r = 0.0f;
        r += Input.GetAxis("J_SecondaryVertical");
        return r;
        //return Mathf.Clamp(r, -1.0f, 1.0f);
    }
    public static Vector3 MainJoystick()
    {
        return new Vector3(MainHorizontal(), 0, MainVertical());
    }

    public static bool AButton()
    {
        
        return Input.GetButtonDown("A");
    }
    public static bool BButton()
    {
        
        return Input.GetButtonDown("B");
    }

    public static bool XButton()
    {
        
        return Input.GetButtonDown("X");
    }
    public static bool YButton()
    {
        
        return Input.GetButtonDown("Y");
    }

    public static bool L3Button()
    {
        
        return Input.GetButton("L3");
    }

    public static bool R3Button()
    {
       
        return Input.GetButton("R3");
    }

    public static bool StartButton()
    {
        return Input.GetButtonDown("Start");
    }

    public static bool SelectButton()
    {
        return Input.GetButtonDown("Select");
    }
}
