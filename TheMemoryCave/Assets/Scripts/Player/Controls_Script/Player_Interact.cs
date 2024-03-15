using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player_Interact : MonoBehaviour
{
    [SerializeField] PreviousPositionSO previousPosition;
    Player_Controls playerControls;
    Interactable currentInteract;
    int curScene;

    static bool initialScene = true;

    void Awake()
    {
        curScene = SceneManager.GetActiveScene().buildIndex;
        playerControls = new();
        playerControls.Interact.Enable();
        playerControls.Interact.Interact.performed += ActivateInteractable;

        while(previousPosition.LastPositionAtScene.Count < SceneManager.sceneCountInBuildSettings)
        {
            previousPosition.LastPositionAtScene.Add(Vector3.zero);
        }

        currentInteract = null;
        if(initialScene) { 
            initialScene = false;
            return;
        }

        transform.position = previousPosition.LastPositionAtScene[curScene];
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Interactable i = other.GetComponent<Interactable>();
        if(!i) { return; }
        // Debug.Log("I am on " + other.name);
        currentInteract = i;
    }

    void ActivateInteractable(InputAction.CallbackContext context)
    {
        if(!context.performed || !currentInteract) { return; }
        previousPosition.LastPositionAtScene[curScene] = transform.position; 
        currentInteract.Interact();
    }
}
