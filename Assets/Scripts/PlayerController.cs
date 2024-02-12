using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] float moveSpeed = 1;
    [SerializeField] Animator animator;

    private bool isMoving = false;

    // Start is called before the first frame update
    void Awake()
    {
        //Chaching
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Old movement behaviour
        /*rb.velocity = new Vector3(
            InputManager.movementInput.x * Time.deltaTime, 
            rb.velocity.y, 
            -InputManager.movementInput.y * moveSpeed * Time.deltaTime);*/

        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void UpdateAnimation()
    {
        animator.SetFloat("xSpeed", InputManager.movementInput.x);
        animator.SetFloat("zSpeed", InputManager.movementInput.y);    
    }
    
    private void Move()
    {
        Vector3 moveInput = new Vector3(InputManager.movementInput.x, 0, InputManager.movementInput.y);
        Vector3 moveDirection = (transform.forward * moveInput.z + transform.right * moveInput.x).normalized;
        moveDirection.y = 0;        // Ensure movement is only horizontal
        
        if(moveInput.z > 0)
        {
            if (!isMoving)
            {
                moveDirection = Camera.main.transform.forward;
                moveDirection.y = 0;
                
                TurnTowardsMovementDirection(moveDirection);
                isMoving = true;
            }
        }
        else
        {
            isMoving = false;
        }

        Vector3 movement = moveDirection.normalized * (moveSpeed * Time.fixedDeltaTime);
        //rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
        
        rb.MovePosition(rb.position + movement);
    }

    private void TurnTowardsMovementDirection(Vector3 moveDirection)
    {
        // Calculate the target rotation based on the movement direction
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
        rb.rotation = targetRotation;
    }
}
