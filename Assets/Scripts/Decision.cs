using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*public class Decision : MonoBehaviour {

    public int num;
    public Text text;
}*/
public class Decision
{
    public int num;
    public Text text;
    public Decision(int aNum,string aName)
    {
        num = aNum;
        text.text = aName;
    }
}