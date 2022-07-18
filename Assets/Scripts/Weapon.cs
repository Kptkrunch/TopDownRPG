using UnityEngine;

public class Weapon : MonoBehaviour
{
	public int damage = 6;
	public int hitForce = 200;
	
	private SpriteRenderer _spriteRenderer;
	private HitBox _hitBox; // the hit-box child tied to this weapon

	protected void Start()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_hitBox = GetComponentInChildren<HitBox>();
		_hitBox.attackDamage = damage;
		_hitBox.hitForce = hitForce;
	}
}
