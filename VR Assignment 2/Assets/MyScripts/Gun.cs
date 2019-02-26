using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public OVRInput.Controller gunController;
    public Rigidbody projectile;
    public float speed = 20;
    public float gunTriggerThreshold;
    float gunTriggerValue;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gunTriggerValue = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, gunController);
        if (gunTriggerValue > gunTriggerThreshold)
        {
            Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(1, 0, speed));
            Debug.Log("Shot fired!");
        }
    }
}
