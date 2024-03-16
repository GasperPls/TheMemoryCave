using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance {get; private set;}
    public static List<string> Keys { get; private set;} = new();
    private void Awake() {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
    }

    public void AddKey(Key key)
    {
        Keys.Add(key.name);
        Debug.Log("Added " +  key);
    }

    public bool FindKey(Key key)
    {
        return Keys.Find(x => key) != null;
    }
}
