using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestItem : InteractableObject
{
    public override void Interact()
    {
        base.Interact();
        this.gameObject.SetActive(false);
        base.EndInteract();
    }
}