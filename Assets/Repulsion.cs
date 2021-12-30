using UnityEngine;

public class Repulsion : MonoBehaviour
{
    public float forceMultiplier;
    public Vector3 repulseDirection = new Vector3(0, 0, 0);
    public ForceMode fm;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ball") && other.attachedRigidbody)
        {
            float distance = Vector3.Distance(other.transform.position,transform.position);
            if (CheckAngle(other.transform))
            {
                other.attachedRigidbody.AddForce(transform.parent.forward * 1 / distance * forceMultiplier * Time.deltaTime, fm);
                other.transform.LookAt(other.transform.position + transform.parent.forward);
                other.SendMessage("SetRotating", true);
            }
            else
                other.SendMessage("SetRotating", false);
        }
    }
 
    public bool CheckAngle(Transform other)
    {
        Vector3 targetDir = other.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);
        return (0 < angle && angle < 90);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
            other.SendMessage("SetRotating", false);
    }

   
}
