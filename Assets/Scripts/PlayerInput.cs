using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float speed = 1f;
    public FloatingJoystick joystick;
    private CharacterController controller;
    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>(); 
    }

    void Update()
    {
        Move(new Vector3(-joystick.Horizontal, 0, -joystick.Vertical));        
    }
    
    void Move(Vector3 moveVector)
    {
        if (moveVector != Vector3.zero)
        {
            animator.SetBool("isRun", true);
            transform.LookAt(transform.position + moveVector);
        }
        else
        {
            animator.SetBool("isRun", false);
        }
    }
}
