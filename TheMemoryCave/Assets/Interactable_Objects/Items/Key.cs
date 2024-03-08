using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Item
{
    protected override void UseItem()
    {
        Debug.Log("I love waffles");
    }
}
