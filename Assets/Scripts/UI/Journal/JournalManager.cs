using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalManager : MonoBehaviour {

    public GameObject spells;
    public GameObject notes;


    public void OpenSpells()
    {
        spells.SetActive(true);
        notes.SetActive(false);
    }

    public void OpenNotes()
    {
        notes.SetActive(true);
        spells.SetActive(false);
    }


}
