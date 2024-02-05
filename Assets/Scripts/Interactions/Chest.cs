using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : AbstractInteractable
{
    private void Open()
    {
        Debug.Log("Chest Opened");
    }

    public override void Interact()
    {
        Open();
    }
}
