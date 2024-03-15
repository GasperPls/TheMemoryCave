using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_Storage_Object", menuName = "ScriptableObjects/Storage")]
public class StorageSO : ScriptableObject
{
    public List<Item> storage;
}
