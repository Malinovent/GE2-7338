using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    
    [SerializeField] PlayerController playerController;
    

    private void LateUpdate()
    {
        UpdateLocalAnimator();
        
        animator.SetBool("isAiming", InputManager.isAimingInput);
        animator.SetBool("isMoving", playerController.IsMoving);
    }

    void UpdateLocalAnimator()
    {
        animator.SetFloat("speedX", InputManager.movementInput.x);
        animator.SetFloat("speedZ",  InputManager.movementInput.y);
    }
}
