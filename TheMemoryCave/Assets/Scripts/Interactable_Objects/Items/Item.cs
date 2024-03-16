using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : Interactable
{
    static private bool pickedUp = false;
    public bool IsConsumable {get; protected set;} = false;
    protected abstract void UseItem();
    public sealed override void Interact()
    {
        if(pickedUp) { return; }
        pickedUp = true;
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<Collider2D>().enabled = false;
        PlayerHandler.Instance.GetComponent<Player_Inventory>().AddToInventory(this);
    }
}
