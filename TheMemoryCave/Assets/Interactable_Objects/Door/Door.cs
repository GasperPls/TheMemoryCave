using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : Interactable
{
    [SerializeField] Key key;
    [SerializeField][Min(0)] int sceneNumber;

    private void Awake() {
        if(sceneNumber > SceneManager.sceneCountInBuildSettings) 
        {
            Debug.LogError("Door " + this.name + " is trying to load a scene out of range");
        }
    }
    public override void Interact()
    {
        // if(key) {
        //     //if player doesn't have key
        //     //  let player know, they need key
        // }
        LoadScene();
    }

    private void LoadScene()
    {
        // exiting transition?
        
        SceneManager.LoadScene(sceneNumber);
    }
}
