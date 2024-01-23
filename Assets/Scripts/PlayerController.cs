using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1;
    
    Rigidbody rb;
    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        //Caching
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.velocity = new Vector3(InputManager.movementInput.x * moveSpeed, rb.velocity.y, InputManager.movementInput.y * moveSpeed);
        MoveInDirectionOfCamera();
    }

    private void MoveInDirectionOfCamera()
    {
        // Get the input from the InputManager, I separate the inputs to make it easier to understand
        float horizontalInput = InputManager.movementInput.x;
        float verticalInput = InputManager.movementInput.y;

        // Calculate the FORWARD direction relative to the camera
        Vector3 forwardDirection = Camera.main.transform.forward;
        forwardDirection.y = 0; // Remove vertical movement

        // Calculate the RIGHT direction relative to the camera
        Vector3 rightDirection = Camera.main.transform.right;

        // Combine the forward and right direction into a single vector
        Vector3 movementDirection = forwardDirection * verticalInput + rightDirection * horizontalInput;
        movementDirection.Normalize(); // Ensure the direction vector has a length of 1

        // Apply the movement to the Rigidbody
        Vector3 movement = movementDirection * (moveSpeed * Time.deltaTime);
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
        if (movementDirection != Vector3.zero)
        {
            TurnTowardsMovementDirection(movementDirection);
        }
    }


    //Eventually, we will be using this method instead for a better feeling.
    //The player will only move forward relative to the camera, not left, right or backwards
    private void MoveOnlyForwardRelativeToCamera()
    {
        Vector3 moveInput = new Vector3(InputManager.turnInput.x, 0, InputManager.turnInput.y);
        Vector3 moveDirection = (transform.forward * moveInput.z + transform.right * moveInput.x).normalized;
        moveDirection.y = 0;        

        if (moveInput.z > 0)
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
        
        rb.MovePosition(rb.position + movement);
    }

    //This function will make sure that the player is rotated towards the direction assigned in the parameter
    private void TurnTowardsMovementDirection(Vector3 moveDirection)
    {
        //This will create a rotation that looks in the direction of the moveDirection parameter
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection); 
        rb.rotation = targetRotation;
    }

}
