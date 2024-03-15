using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_Previous_Position", menuName = "Settings/LastPosition")]
public class StorageSO : ScriptableObject
{
    public List<Vector3> LastPositionAtScene;
}
