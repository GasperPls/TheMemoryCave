using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Key : Item
{
    private void Awake() {
        base.IsConsumable = true;
    }

    protected override void UseItem()
    {
        Debug.Log("I love waffles");
    }
}
