using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
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
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * raycastDistance);
    }

    private void OnTriggerEnter(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();

        if (interactable != null)
        {
            _currentInteractable = interactable;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        
        if(interactable == _currentInteractable)
        {
            _currentInteractable = null;
        }
    }
}
