using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;

    private Vector2 _moveInput;
    public Rigidbody2D playerRb2D;
    public Animator playerAnimator;
    private BoxCollider2D _boxCollider2D;

    void Start() {
        playerRb2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update() {
        Run();
        FlipSprite();
        AnimationUpdater();
    }

    private void OnMove(InputValue value) {

        _moveInput = value.Get<Vector2>();
    }

    public void OnFire()
    {
        //playerAnimator.Play("PlayerBrandish");
        print("heck yah, time for adventure!!!");
    }

    // Player actions
    void Run() {   
        
        Vector2 playerVelocity = new Vector2 (_moveInput.x * (runSpeed * Time.deltaTime),
                                                _moveInput.y * (runSpeed * Time.deltaTime));
        
        playerRb2D.velocity = playerVelocity;
    }

    // Sprite functionality
    void FlipSprite() {
        bool playerHasHorizontalSpeed = Mathf.Abs(playerRb2D.velocity.x) > Mathf.Epsilon;

        if(playerHasHorizontalSpeed) {
            transform.localScale = new Vector2(Mathf.Sign(playerRb2D.velocity.x), 1.0f);
        }
    }

    void AnimationUpdater()
    {
        playerAnimator.SetFloat("Horizontal", _moveInput.x);
        playerAnimator.SetFloat("Vertical", _moveInput.y);
        playerAnimator.SetFloat("MoveSpeed", _moveInput.sqrMagnitude);
    }
}

