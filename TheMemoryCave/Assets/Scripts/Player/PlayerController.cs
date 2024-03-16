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

        Debug.Log("New scene loaded!");
        Debug.Log("I have these keys: ");
        foreach (string key in Keys)
        {
            Debug.Log(key);
        }
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
