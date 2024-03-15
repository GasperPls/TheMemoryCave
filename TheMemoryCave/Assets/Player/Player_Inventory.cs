using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Inventory : MonoBehaviour
{
    public static Player_Inventory Instance { get; private set; }

    public List<Item> inventory;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }

        inventory = new();
    }

    public void AddToInventory(Item item)
    {
        Item copy = item;
        inventory.Add(copy);
    }

    public bool FindItem(Item item)
    {
        return inventory.Find(x => item);
    }
}
