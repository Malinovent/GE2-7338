using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : AbstractInteractable
{
    public void Open()
    {
        Debug.Log("Door Opened");
        transform.Rotate(0, 90, 0);
    }
            
    public override void Interact()
    {
        Open();
    }
}
