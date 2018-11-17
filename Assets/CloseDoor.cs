using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour {

    public bool isTouch;
    public float cool;
    public float coolDown;
    public float speed;
    public Quaternion quaternion;
    float timeCount = 0;
	// Use this for initialization
	void Start () {
        quaternion = transform.rotation;
        print(quaternion.eulerAngles.y);
	}
	
	// Update is called once per frame
	void Update () {
        if (isTouch)
        {
            cool -= Time.deltaTime;
            if (cool <= 0)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, quaternion, timeCount);
                timeCount = timeCount + Time.deltaTime*0.1f;
                print(transform.rotation.eulerAngles.y);
                if (transform.rotation.eulerAngles.y >= 359.5f || transform.rotation.eulerAngles.y <= 0.5f)
                {
                    isTouch = false;
                    timeCount = 0;
                }
            }
        }
	}
}
