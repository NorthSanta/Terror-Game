using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoopDoor : MonoBehaviour {
    // Use this for initialization
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "StopDoor")
        {
            rb.freezeRotation = true;
            rb.isKinematic = true;
        }
    }
}
