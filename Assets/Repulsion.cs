using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repulsion : MonoBehaviour
{
    public float forceMultiplier;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ball")&&other.attachedRigidbody)
        other.attachedRigidbody.AddForce((other.transform.position - transform.position)*forceMultiplier);
    }
}
