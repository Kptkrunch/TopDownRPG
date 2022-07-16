using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;

    private Vector2 _moveInput, _pointerInput;
    public Rigidbody2D playerRb2D;
    public Animator playerAnimator;
    private WeaponParent _weaponParent;
    
    void Start() {
        playerRb2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        _weaponParent = GetComponentInChildren<WeaponParent>();
    }

    void FixedUpdate() {
        Run();
    }

    private void Update()
    {
        _pointerInput = Mouse.current.position.ReadValue();
        _weaponParent.PointerPosition = _pointerInput;
        
        AnimationUpdater();
        FlipSprite();
        
        


        Debug.Log($"mouse position {_pointerInput}");
        Debug.Log($"weapon parent position {_weaponParent.PointerPosition}");
    }

    // Input Listeners
    private void OnMove(InputValue value) {

        _moveInput = value.Get<Vector2>();
    }

    public void OnFire()
    {
        print("heck yah, time for adventure!!!");
    }

    // Player actions
    void Run() {
        Vector2 playerVelocity = new Vector2 (_moveInput.x * runSpeed, _moveInput.y * runSpeed);
        playerRb2D.velocity = playerVelocity;
    }
    
    // Animation Logic
    void AnimationUpdater()
    {
        playerAnimator.SetFloat("Horizontal", _moveInput.x);
        playerAnimator.SetFloat("Vertical", _moveInput.y);
        playerAnimator.SetFloat("MoveSpeed", _moveInput.sqrMagnitude);
    }
    void FlipSprite() {
        bool playerHasHorizontalSpeed = Mathf.Abs(playerRb2D.velocity.x) > Mathf.Epsilon;
        if(playerHasHorizontalSpeed) {
            transform.localScale = new Vector2(Mathf.Sign(playerRb2D.velocity.x), 1.0f);
        }
    }

}

