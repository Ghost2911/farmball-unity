using UnityEngine;

public class FollowCamera : MonoBehaviour
{
	public Transform target;
	public bool followPlayerDefault = true;

	[Range(0f, 10f)]
	public float turnSpeed = 1.5f;
	public float followSpeed = 1f;

	public Vector3 Offset;
	private Quaternion startRotation;

	void Awake()
	{
		startRotation = transform.localRotation;
	}

	void FixedUpdate() 
	{
		Vector3 targetPos = new Vector3(target.position.x, target.transform.position.y, target.transform.position.z)+Offset;
		transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed / 10);  
	}
}