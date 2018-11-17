using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBindings : MonoBehaviour {
    public static Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public static int invertM;
    public Color32 selected;
    public Color32 normal;
    public Toggle toggle;
    public Text interact, sprint, crouch, pause, castS, cancelS, jump, journal;
    private GameObject currentKey;
	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("Invert"))
        {
            invertM = PlayerPrefs.GetInt("Invert");
            if(invertM == 1)
            {
                toggle.isOn = false;
            }
            else
            {
                toggle.isOn = true;
            }
        }
        else
        {
            invertM = 1;
            PlayerPrefs.SetInt("Invert",invertM);
            toggle.isOn = false;
        }

        if (PlayerPrefs.HasKey("Interact"))
        {
            keys["Interact"] = (KeyCode)PlayerPrefs.GetInt("Interact");
        }
        else
        {
            print("NoKey");
            keys.Add("Interact", KeyCode.E);
            PlayerPrefs.SetInt("Interact", (int)keys["Interact"]);
        }

        if (PlayerPrefs.HasKey("Sprint"))
        {
            keys["Sprint"] = (KeyCode)PlayerPrefs.GetInt("Sprint");
        }
        else
        {
            keys.Add("Sprint", KeyCode.LeftShift);
            PlayerPrefs.SetInt("Sprint", (int)keys["Sprint"]);
        }

        if (PlayerPrefs.HasKey("Crouch"))
        {
            keys["Crouch"] = (KeyCode)PlayerPrefs.GetInt("Crouch");
        }
        else
        {
            keys.Add("Crouch", KeyCode.LeftControl);
            PlayerPrefs.SetInt("Crouch", (int)keys["Crouch"]);
        }

        if (PlayerPrefs.HasKey("Pause"))
        {
            keys["Pause"] = (KeyCode)PlayerPrefs.GetInt("Pause");
        }
        else
        {
            keys.Add("Pause", KeyCode.Escape);
            PlayerPrefs.SetInt("Pause", (int)keys["Pause"]);
        }

        if (PlayerPrefs.HasKey("CastSpell"))
        {
            keys["CastSpell"] = (KeyCode)PlayerPrefs.GetInt("CastSpell");
        }
        else
        {
            keys.Add("CastSpell", KeyCode.Mouse0);
            PlayerPrefs.SetInt("CastSpell", (int)keys["CastSpell"]);
        }

        if (PlayerPrefs.HasKey("CancelSpell"))
        {
            keys["CancelSpell"] = (KeyCode)PlayerPrefs.GetInt("CancelSpell");
        }
        else
        {
            keys.Add("CancelSpell", KeyCode.Mouse1);
            PlayerPrefs.SetInt("CancelSpell", (int)keys["CancelSpell"]);
        }

        if (PlayerPrefs.HasKey("Jump"))
        {
            keys["Jump"] = (KeyCode)PlayerPrefs.GetInt("Jump");
        }
        else
        {
            keys.Add("Jump", KeyCode.Space);
            PlayerPrefs.SetInt("Jump", (int)keys["Jump"]);
        }

        if (PlayerPrefs.HasKey("Journal"))
        {
            keys["Journal"] = (KeyCode)PlayerPrefs.GetInt("Journal");
        }
        else
        {
            keys.Add("Journal", KeyCode.J);
            PlayerPrefs.SetInt("Journal", (int)keys["Journal"]);
        }

        if (keys["Interact"] == KeyCode.Mouse0)
        {
            interact.text = "MB1";
        }else if(keys["Interact"] == KeyCode.Mouse1)
        {
            interact.text = "MB2";
        }
        else if (keys["Interact"] == KeyCode.Mouse2)
        {
            interact.text = "MB3";
        }
        else
        {
            interact.text = keys["Interact"].ToString();
        }

        if (keys["Sprint"] == KeyCode.Mouse0)
        {
            sprint.text = "MB1";
        }
        else if (keys["Sprint"] == KeyCode.Mouse1)
        {
            sprint.text = "MB2";
        }
        else if (keys["Sprint"] == KeyCode.Mouse2)
        {
            sprint.text = "MB3";
        }
        else
        {
            sprint.text = keys["Sprint"].ToString();
        }

        if (keys["Crouch"] == KeyCode.Mouse0)
        {
            crouch.text = "MB1";
        }
        else if (keys["Crouch"] == KeyCode.Mouse1)
        {
            crouch.text = "MB2";
        }
        else if (keys["Crouch"] == KeyCode.Mouse2)
        {
            crouch.text = "MB3";
        }
        else
        {
            crouch.text = keys["Crouch"].ToString();
        }

        if (keys["Pause"] == KeyCode.Mouse0)
        {
            pause.text = "MB1";
        }
        else if (keys["Pause"] == KeyCode.Mouse1)
        {
            pause.text = "MB2";
        }
        else if (keys["Pause"] == KeyCode.Mouse2)
        {
            pause.text = "MB3";
        }
        else
        {
            pause.text = keys["Pause"].ToString();
        }

        if (keys["CastSpell"] == KeyCode.Mouse0)
        {
            castS.text = "MB1";
        }
        else if (keys["CastSpell"] == KeyCode.Mouse1)
        {
            castS.text = "MB2";
        }
        else if (keys["CastSpell"] == KeyCode.Mouse2)
        {
            castS.text = "MB3";
        }
        else
        {
            castS.text = keys["CastSpell"].ToString();
        }

        if (keys["CancelSpell"] == KeyCode.Mouse0)
        {
            cancelS.text = "MB1";
        }
        else if (keys["CancelSpell"] == KeyCode.Mouse1)
        {
            cancelS.text = "MB2";
        }
        else if (keys["CancelSpell"] == KeyCode.Mouse2)
        {
            cancelS.text = "MB3";
        }
        else
        {
            cancelS.text = keys["CancelSpell"].ToString();
        }

        if (keys["Jump"] == KeyCode.Mouse0)
        {
            jump.text = "MB1";
        }
        else if (keys["Jump"] == KeyCode.Mouse1)
        {
            jump.text = "MB2";
        }
        else if (keys["Jump"] == KeyCode.Mouse2)
        {
            jump.text = "MB3";
        }
        else
        {
            jump.text = keys["Jump"].ToString();
        }
        if (keys["Journal"] == KeyCode.Mouse0)
        {
            journal.text = "MB1";
        }
        else if (keys["Journal"] == KeyCode.Mouse1)
        {
            journal.text = "MB2";
        }
        else if (keys["Journal"] == KeyCode.Mouse2)
        {
            journal.text = "MB3";
        }
        else
        {
            journal.text = keys["Journal"].ToString();
        }

    }
	
    void OnGUI()
    {
        if(currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                PlayerPrefs.SetInt(currentKey.name, (int)e.keyCode);
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
            }else if (e.shift)
            {
                keys[currentKey.name] = KeyCode.LeftShift;
                PlayerPrefs.SetInt(currentKey.name, (int)KeyCode.LeftShift);
                currentKey.transform.GetChild(0).GetComponent<Text>().text = KeyCode.LeftShift.ToString();
                currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
            }
            else if (e.button == 0 && e.isMouse)
            {
                keys[currentKey.name] = KeyCode.Mouse0;
                PlayerPrefs.SetInt(currentKey.name, (int)KeyCode.Mouse0);
                currentKey.transform.GetChild(0).GetComponent<Text>().text = "MB1";
                currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
            }
            else if (e.button == 1 && e.isMouse)
            {
                keys[currentKey.name] = KeyCode.Mouse1;
                PlayerPrefs.SetInt(currentKey.name, (int)KeyCode.Mouse1);
                currentKey.transform.GetChild(0).GetComponent<Text>().text = "MB2";
                currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
            }
            else if (e.button == 2 && e.isMouse)
            {
                keys[currentKey.name] = KeyCode.Mouse1;
                PlayerPrefs.SetInt(currentKey.name, (int)KeyCode.Mouse1);
                currentKey.transform.GetChild(0).GetComponent<Text>().text = "MB3";
                currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
            }
            else if (e.control)
            {
                keys[currentKey.name] = KeyCode.LeftControl;
                PlayerPrefs.SetInt(currentKey.name, (int)KeyCode.LeftControl);
                currentKey.transform.GetChild(0).GetComponent<Text>().text = KeyCode.LeftShift.ToString();
                currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
            }
        }

    }

    public void changeKey(GameObject clicked)
    {
        if(currentKey != null)
        {
            currentKey.GetComponent<Image>().color = normal;
        }
        currentKey = clicked;
        currentKey.GetComponent<Image>().color = selected;
    }

    public void InvertMouse(GameObject toggle)
    {
        
        if (toggle.GetComponent<Toggle>().isOn)
        {
            invertM = -1;
            PlayerPrefs.SetInt("Invert", invertM);
        }
        else
        {
            invertM = 1;
            PlayerPrefs.SetInt("Invert", invertM);
        }
    }

    public void ResetBindings()
    {
        keys["Interact"] = KeyCode.E;
        PlayerPrefs.SetInt("Interact", (int)keys["Interact"]);
        interact.text = keys["Interact"].ToString();

        keys["Sprint"] = KeyCode.LeftShift;
        PlayerPrefs.SetInt("Sprint", (int)keys["Sprint"]);
        sprint.text = keys["Sprint"].ToString();

        keys["Crouch"] = KeyCode.LeftControl;
        PlayerPrefs.SetInt("Crouch", (int)keys["Crouch"]);
        crouch.text = keys["Crouch"].ToString();

        keys["Pause"] = KeyCode.Escape;
        PlayerPrefs.SetInt("Pause", (int)keys["Pause"]);
        pause.text = keys["Pause"].ToString();

        keys["CastSpell"] = KeyCode.Mouse0;
        PlayerPrefs.SetInt("CastSpell", (int)keys["CastSpell"]);
        castS.text = "MB1";

        keys["CancelSpell"] = KeyCode.Mouse1;
        PlayerPrefs.SetInt("CancelSpell", (int)keys["CancelSpell"]);
        cancelS.text = "MB2";

        keys["Jump"] = KeyCode.Space;
        PlayerPrefs.SetInt("Jump", (int)keys["Jump"]);
        jump.text = keys["Jump"].ToString();

        keys["Journal"] = KeyCode.J;
        PlayerPrefs.SetInt("Journal", (int)keys["Journal"]);
        jump.text = keys["Journal"].ToString();

        invertM = 1;
        toggle.isOn = false;
        PlayerPrefs.SetInt("Invert", invertM);

    }
}
