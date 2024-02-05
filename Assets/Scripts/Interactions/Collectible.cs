using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : AbstractInteractable
{
    private void Collect()
    {
        Debug.Log("Collectible Collected");
        Destroy(this.gameObject);
    }

    public override void Interact()
    {
        Collect();
    }
}
