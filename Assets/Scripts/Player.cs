using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Vector2 _moveInput;
    [SerializeField] private float moveSpeed = 1f;

    private BoxCollider2D _boxCollider2D;
    private RaycastHit2D _hit;

    void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }


    void FixedUpdate()
    {
        FlipSprite();
        PlayerMovement();
    }

    void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }

    void OnFire()
    {
        
    }

    private void PlayerMovement()
    {
        _hit = Physics2D.BoxCast(transform.position, _boxCollider2D.size, 0, new Vector2(0, _moveInput.y),
            Mathf.Abs(_moveInput.y * Time.deltaTime), LayerMask.GetMask("Actor", "Collision"));
        if (!_hit.collider)
        {
            transform.Translate(0, _moveInput.y * Time.deltaTime * moveSpeed, 0);
        }
        
        _hit = Physics2D.BoxCast(transform.position, _boxCollider2D.size, 0, new Vector2(_moveInput.x, 0),
            Mathf.Abs(_moveInput.x * Time.deltaTime), LayerMask.GetMask("Actor", "Collision"));
        if (!_hit.collider)
        {
            transform.Translate(_moveInput.x * Time.deltaTime * moveSpeed, 0, 0);
        }
    }

    private void FlipSprite()
    {
        if (_moveInput.x > 0)
        {
            transform.localScale = Vector2.one;
        } else if (_moveInput.x < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }
  
}
