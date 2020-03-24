using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Arrow : MonoBehaviourPun
{
    Rigidbody myBody;
    private float timer;
    private bool hitSomething = false;
    // Start is called before the first frame update
    void Start()
    {
            myBody = GetComponent<Rigidbody>();
            transform.rotation = Quaternion.LookRotation(myBody.velocity);
    }

    // Update is called once per frame
    void Update()
    {
         if (!hitSomething)
        {
            transform.rotation = Quaternion.LookRotation(myBody.velocity);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        hitSomething = true;
    }
}
