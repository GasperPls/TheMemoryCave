using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1;
    [SerializeField] float jumpPower = 50;
    /// <summary> How much time, in seconds, between jumps there should be </summary>
    // [SerializeField] float jumpDelay = 1f;
    [SerializeField] bool isDoubleJump = true;
    [SerializeField] float floatGravScale = 1f;
    [SerializeField] float dashDist = 1f;
    

    Player_Controls playerControls;
    Rigidbody2D rb;
    int maxJumps = 2;
    int jumpCounter;
    float defaultGravScale = 1;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerControls = new();
        
        playerControls.Movement.Enable();
        playerControls.Movement.Dash.performed += ActivateDash;
        playerControls.Movement.Jump.performed += ActivateJump;

        jumpCounter = maxJumps;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        ResetJumpCounter();
        Move();
        rb.gravityScale = (rb.velocity.y < 0f && playerControls.Movement.Float.inProgress) ? floatGravScale : defaultGravScale;
    }

    private void Move()
    {
        float moveVelocityX = playerControls.Movement.Forward.ReadValue<float>() * moveSpeed;
        rb.velocity = new Vector2(moveVelocityX, rb.velocity.y);
    }

    private void ResetJumpCounter()
    {
        maxJumps = (isDoubleJump) ? 2 : 1;
        // Temp way to reset jumps
        // Need to replace the condition with a ground checker . . . if(touchingGround) { . . . }
        if (rb.velocity.y >= -float.Epsilon && rb.velocity.y <= float.Epsilon && jumpCounter < maxJumps)
        {
            Debug.Log("Reset Jumps!");
            jumpCounter = maxJumps;
        }
    }

    void ActivateJump(InputAction.CallbackContext context) 
    {
        if(!context.performed || jumpCounter <= 0) { return; }
        // Debug.Log("Time since last jump: " + Time.time + "\nCurrent Time: " + timeSinceLastJump);
        // if(Time.time - timeSinceLastJump <= jumpDelay) { return; }
        // timeSinceLastJump = Time.time;
        Vector2 jumpForce = jumpPower * this.transform.up;
        if(rb.velocity.y < 0) { rb.velocity = new Vector2(rb.velocity.x, 0); }
        rb.AddForce(jumpForce, ForceMode2D.Impulse);
        jumpCounter--;
        Debug.Log("Jumps left: " + jumpCounter);
    }

    void ActivateDash(InputAction.CallbackContext context)
    {
        if(!context.performed) { return; }
        Debug.Log("Am Dashing");
        int dashRight = (playerControls.Movement.Forward.ReadValue<float>() > 0f) ? 1 :  -1;
        float dashTo = transform.position.x + dashDist * dashRight;
        transform.position = new Vector2(dashTo,transform.position.y);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + Vector3.right * dashDist, 0.5f);
        Gizmos.DrawWireSphere(transform.position + Vector3.left * dashDist, 0.5f);
    }
}
