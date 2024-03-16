using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : Interactable
{
    [SerializeField] Key key;
    [SerializeField][Min(-1)] int sceneNumber;

    private void Awake() {
        if(sceneNumber > SceneManager.sceneCountInBuildSettings) 
        {
            Debug.LogError("Door " + this.name + " is trying to load a scene out of range");
        }
    }
    public override void Interact()
    {
        if(sceneNumber == -1) { return; }
        if(key && !PlayerController.Instance.FindKey(key))
        {
            CantOpenDoor();
            return;
        }
        LoadScene();
    }

    private void CantOpenDoor()
    {
        Debug.Log("You can't open the door. You don't have the right key!");
    }

    private void LoadScene()
    {
        // exiting transition?
        
        SceneManager.LoadScene(sceneNumber);
    }
}
