using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;

    Vector2 moveInput;
    Rigidbody2D playerRB2D;
    Animator playerAnimator;

    void Start() {
        playerRB2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update() {
        Run();
        FlipSprite();
    }

    void OnMove(InputValue value) {

        moveInput = value.Get<Vector2>();
    }

    // Player actions
    void Run() {   
        
        Vector2 playerVelocity = new Vector2 (moveInput.x * runSpeed, moveInput.y * runSpeed);
        playerRB2D.velocity = playerVelocity;

        if(Mathf.Abs(playerRB2D.velocity.x) > Mathf.Epsilon) {
            playerAnimator.SetBool("isMoving", true);
        } else {
            playerAnimator.SetBool("isMoving", false);
        }
        
        if(Mathf.Abs(playerRB2D.velocity.y) > Mathf.Epsilon) {
            //playerAnimator.SetBool("isMoving", true);
            playerAnimator.SetBool("isRunningUp", true);
        } else {
            //playerAnimator.SetBool("isMoving", false);
            playerAnimator.SetBool("isRunningUp", false);
        }
    }

    // Sprite functionality
    void FlipSprite() {
        bool playerHasHorizontalSpeed = Mathf.Abs(playerRB2D.velocity.x) > Mathf.Epsilon;

        if(playerHasHorizontalSpeed) {
            transform.localScale = new Vector2(Mathf.Sign(playerRB2D.velocity.x), 1.0f);
        }
    }
}