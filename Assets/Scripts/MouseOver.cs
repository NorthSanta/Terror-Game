using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseOver : MonoBehaviour {
    
   
    private Text text;
    private void Start()
    {
        text = GetComponent<Text>();
    }
    public void ScaleUp()
    {
        text.fontSize += 5;
    }
    public void ScaleDown()
    {
        text.fontSize -= 5;
    }

}
