using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    public float dist = 5;
    private Rigidbody rb;
    public Transform player;
    public float power;

    // Use this for initialization
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 up = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, up, out hit, dist))
        {
            if (hit.collider.gameObject.tag == "Door")
            {
                rb = hit.collider.gameObject.GetComponent<Rigidbody>();
                hit.collider.gameObject.GetComponent<CloseDoor>().isTouch = true;
                hit.collider.gameObject.GetComponent<CloseDoor>().cool = 5;
                if (Input.GetKey("w"))
                {
                    rb.AddForce(transform.forward * power);
                }
            }
        }
    }
}
