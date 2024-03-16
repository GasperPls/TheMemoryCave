using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Key : Interactable
{
    public sealed override void Interact()
    {
        PlayerController.Instance.AddKey(this);
        Destroy(gameObject);
    }
}
