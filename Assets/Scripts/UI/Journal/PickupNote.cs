using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupNote : Interactable {
    [SerializeField]
    private int index;

    public NoteManager manager;

    public override void Interact()
    {
        for(int i = 0; i < manager.notes.Length; i++)
        {
            if(manager.notes[i].index == index)
            {
                manager.notes[i].setFound();
            }
        }
    }
}
