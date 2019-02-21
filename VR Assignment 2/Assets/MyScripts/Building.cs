using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.rigidbody == null)
        {
            return;
        }

        Rigidbody rb = collision.rigidbody;
        Missile m = rb.GetComponent<Missile>();

        if(m == null)
        {
            Debug.Log("Hit by " + rb.name);
            return;
        }
       
        Debug.Log("Destroyed by Missile!");
        Destroy(this.gameObject);
    }
}
