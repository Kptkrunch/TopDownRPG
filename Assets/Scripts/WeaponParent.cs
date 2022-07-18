using UnityEngine;
using UnityEngine.InputSystem;


public class WeaponParent : MonoBehaviour
{
	public Vector2 PointerPosition { get; set; }

	private Vector3 _difference;
	private Vector2 _mouseDirection;
	private SpriteRenderer _spriteRenderer;
	private Animator _swordAnimator;
	private CircleCollider2D _hitbox;
	
	private void Awake()
	{
		_spriteRenderer = GetComponentInChildren<SpriteRenderer>();
		_swordAnimator = GetComponentInChildren<Animator>();
		_hitbox = GetComponentInChildren<HitBox>().GetComponent<CircleCollider2D>();
		Debug.Log($"hitbox {_hitbox}");
	}

	private void Update()
	{
		Attack();
	}

	// Weapons facing based on mouse position
	private void PointToMouse()
	{
		if (Camera.main != null) _difference = Camera.main.ScreenToWorldPoint(PointerPosition) - transform.position;
		_difference.Normalize();
		float rotationZ = Mathf.Atan2(_difference.y, _difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
	}
	// Flip the Y axis
	private void SwordOrientation()
	{
		_mouseDirection = new Vector2(PointerPosition.x, Screen.height - PointerPosition.y);

		bool swordFacing;

		if (_mouseDirection.x < Screen.width / 2)
		{
			swordFacing = false;
		}
		else
		{
			swordFacing = true;
		}

		_spriteRenderer.flipY = swordFacing;
	}

	private void Attack()
	{
		if (Mouse.current.rightButton.wasPressedThisFrame)
		{
			_swordAnimator.ResetTrigger("HeavyAttack");
			_swordAnimator.SetTrigger("HeavyAttack");
		}

		if (Mouse.current.leftButton.wasPressedThisFrame)
		{	
			_swordAnimator.ResetTrigger("Attack");
			_swordAnimator.SetTrigger("Attack");
		}
	}
}

