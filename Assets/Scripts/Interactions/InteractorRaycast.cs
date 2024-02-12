using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfactorRaycast : MonoBehaviour
{
    
    private IInteractable _currentInteractable;
    [SerializeField] private float raycastDistance = 5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _currentInteractable?.Interact();
            _currentInteractable = null;
        }
        
        RaycastTarget();
    }

    private void RaycastTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if(Physics.Raycast(ray, out RaycastHit hit, raycastDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if(interactable != null)
            {
                _currentInteractable = interactable;
            }
        }
        else
        {
            _currentInteractable = null;
        }
    }

    private void OnDrawGizmos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(ray.origin, ray.direction * raycastDistance);
    }

  
}
