using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorIK : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform aimPoint;

    private void OnAnimatorIK(int layerIndex)
    {
        if (!animator) return;
        
        animator.SetLookAtPosition(aimPoint.position);
        animator.SetLookAtWeight(1, 0.8f, 0.5f);
    }
}
