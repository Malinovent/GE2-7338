using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractInteractable : MonoBehaviour, IInteractable
{
    public abstract void Interact();
}

