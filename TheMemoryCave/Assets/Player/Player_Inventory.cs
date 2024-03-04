using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Inventory : MonoBehaviour
{
    public static Player_Inventory Instance { get; private set; }

    public List<ItemParentClass> inventory;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }

        inventory = new();
    }

    public void AddToInventory(ItemParentClass item)
    {
        ItemParentClass copy = item;
        inventory.Add(copy);
    }
}
