using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1;
    [SerializeField] float jumpPower = 1;
    Player_Controls playerControls;
    Rigidbody2D rb;
    int jumpCounter = 2;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerControls = new();
        
        playerControls.Movement.Enable();
        playerControls.Movement.Jump.performed += ActivateJump;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ActivateJump(InputAction.CallbackContext context) 
    {
        if(!context.performed || jumpCounter <= 0) { return; }
        Debug.Log("Am jumping!");
        Vector2 jumpForce = jumpPower * this.transform.up;
        rb.AddForce(jumpForce);
        jumpCounter--;
        Debug.Log("Jumps left: " + jumpCounter);
    }
}
