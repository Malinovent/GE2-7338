using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float walkSpeed = 5f;
    [SerializeField] float aimSpeed = 10f;

    private Rigidbody rb;
    private bool isMovingOnZ = false;
    private bool isAiming = false;

    public bool IsMoving;

    // Start is called before the first frame update
    void Awake()
    {
        //Caching
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (InputManager.isAimingInput)
        {
            LateralMovementAim();
        }
        else
        {
            LateralMovementNoAim();
        }
    }

    private void LateralMovementNoAim()
    {
        Vector3 moveInput = new Vector3(InputManager.movementInput.x, 0, InputManager.movementInput.y);
        Vector3 moveDirection = (transform.forward * moveInput.z + transform.right * moveInput.x).normalized;
        moveDirection.y = 0;        // Ensure movement is only horizontal
        
        IsMoving = moveInput != Vector3.zero;
        
        if(moveInput.z > 0)
        {
            if (!isMovingOnZ)
            {
                moveDirection = Camera.main.transform.forward;
                moveDirection.y = 0;
                
                TurnTowardsMovementDirection(moveDirection);
                isMovingOnZ = true;
            }
        }
        else
        {
            //TurnTowardsMovementDirection(moveDirection);
            isMovingOnZ = false;
        }
        
        Vector3 movement = moveDirection.normalized * (walkSpeed * Time.fixedDeltaTime);
        //rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
        
        rb.MovePosition(rb.position + movement);
    }

    private void LateralMovementAim()
    {
        Vector3 moveInput = new Vector3(InputManager.movementInput.x, 0, InputManager.movementInput.y);
        Vector3 moveDirection = (-transform.right * moveInput.z + transform.forward * moveInput.x).normalized;
        moveDirection.y = 0;        // Ensure movement is only horizontal
        
        //Vector3 lookDirection = new Vector3(InputManager.PlayerLookInput.x, 0, InputManager.PlayerLookInput.y);
        Vector3 correctedForward = Quaternion.Euler(0, 90, 0) * Camera.main.transform.forward;
        correctedForward.y = 0;
        TurnTowardsMovementDirectionSmoothly(correctedForward);
        
        Vector3 movement = moveDirection.normalized * (aimSpeed * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + movement);
    }

    private void TurnTowardsMovementDirectionSmoothly(Vector3 lookDirection)
    {
        Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
        // Smoothly rotate towards the target direction
        rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, aimSpeed * Time.fixedDeltaTime);
    }
    
    private void TurnTowardsMovementDirection(Vector3 moveDirection)
    {
        // Calculate the target rotation based on the movement direction
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
        rb.rotation = targetRotation;
    }
}
