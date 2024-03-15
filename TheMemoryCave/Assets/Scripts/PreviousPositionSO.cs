using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_Previous_Position", menuName = "ScriptableObjects/LastPosition")]
public class PreviousPositionSO : ScriptableObject
{
    public List<Vector3> LastPositionAtScene;
}
