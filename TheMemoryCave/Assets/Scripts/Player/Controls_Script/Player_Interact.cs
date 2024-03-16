using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player_Interact : MonoBehaviour
{
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

        currentInteract = null;
        if(initialScene) { 
            initialScene = false;
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Interactable i = other.GetComponent<Interactable>();
        if(!i) { return; }
        Debug.Log("I am on " + other.name);
        currentInteract = i;
    }

    void ActivateInteractable(InputAction.CallbackContext context)
    {
        if(!context.performed || !currentInteract) { return; }
        currentInteract.Interact();
    }
}
