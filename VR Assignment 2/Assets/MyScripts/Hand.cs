using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{

    public OVRInput.Controller myController;
    PickupObject currentAttachment = null;
    public float pickupTriggerThreshold;
    public float releaseTriggerThreshold;
    public bool disappearOnPickup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider c)
    {
        Rigidbody rb = c.attachedRigidbody;

        if(rb == null)
        {
            return;
        }

        PickupObject p = rb.GetComponent<PickupObject>();

        if(p == null)
        {
            return;
        }

        float triggerValue;

        triggerValue = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, myController);
        
       

        if (currentAttachment == null && triggerValue > pickupTriggerThreshold)
        {
            //actually pickup the object
            currentAttachment = p;
            currentAttachment.pickedUp(this.transform);

            if (disappearOnPickup)
            {
                MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();
                foreach (MeshRenderer m in meshRenderers)
                {
                    m.enabled = false;
                }
            }

        }

        if(currentAttachment != null && triggerValue < releaseTriggerThreshold)
        {
            currentAttachment.released(this.transform, OVRInput.GetLocalControllerVelocity(myController));
            currentAttachment = null;

            if (disappearOnPickup)
            {
                MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();
                foreach (MeshRenderer m in meshRenderers)
                {
                    m.enabled = true;
                }
            }

        }

        //Debug.Log("intersecting pickup object " + p.name + " at " + triggerValue);

    }
}
