using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float speed = 1f;
    private CharacterController controller; 
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move(new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical")));        
    }

    void Move(Vector3 moveVector)
    {
        if (moveVector!=Vector3.zero)
            controller.Move(moveVector*Time.deltaTime*speed);
    }
}
