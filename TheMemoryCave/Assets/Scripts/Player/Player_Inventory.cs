using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Inventory : MonoBehaviour
{
    public static Player_Inventory Instance { get; private set; }
    string jsonInventory;
    private List<Item> inventory;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
    }

    public void AddToInventory(Item item)
    {
        item.transform.parent = this.transform;
        item.transform.position = Vector3.zero;
        inventory.Add(item);
    }

    public bool FindItem(Item item)
    {
        return inventory.Find(x => item);
    }

    public void ConsumeItem(Item item)
    {
        inventory.Remove(item);
        Destroy(item);
    }
}
