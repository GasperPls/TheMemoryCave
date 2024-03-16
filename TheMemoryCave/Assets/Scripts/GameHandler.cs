using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";
    public static GameHandler Instance { get; private set; }
    PlayerHandler playerHandler;
    string json;
    private void Awake() {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
    }
}
