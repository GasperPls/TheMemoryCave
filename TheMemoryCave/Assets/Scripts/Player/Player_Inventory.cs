using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Inventory : MonoBehaviour
{
    public static Player_Inventory Instance { get; private set; }

    public StorageSO inventory;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }

        if(!inventory)
        {
            Debug.LogError("Player has no Storage Object!");
        }
    }

    public void AddToInventory(Item item)
    {
        Item copy = item;
        inventory.storage.Add(copy);
    }

    public bool FindItem(Item item)
    {
        return inventory.storage.Find(x => item);
    }
}
