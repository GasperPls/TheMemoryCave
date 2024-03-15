using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : Interactable
{
    public bool IsConsumable {get; protected set;} = false;
    protected abstract void UseItem();
    public sealed override void Interact()
    {
        Player_Inventory.Instance.AddToInventory(this);
        Debug.Log("Added " + this.name + " to my inventory");
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<Collider2D>().enabled = false;
    }
}
