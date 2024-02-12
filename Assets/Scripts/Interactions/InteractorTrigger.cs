using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractorTrigger : MonoBehaviour
{
    private IInteractable _currentInteractable;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _currentInteractable?.Interact();
            _currentInteractable = null;
        }
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
