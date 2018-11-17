using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour {

    public bool found;
    public int index;
    public string titleText;
    public string descriptionText;
    public Text Title;
    public Text Description;

    public void setFound()
    {
        found = true;
        gameObject.SetActive(found);
    }

    public void SetText()
    {
        Title.text = titleText;
        Description.text = descriptionText;
    }
}
