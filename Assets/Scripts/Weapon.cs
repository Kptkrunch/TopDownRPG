using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField] private int attackDamage = 6;
	[SerializeField] private int hitForce = 200;
	
	private HitBox _hitBox; // the hit-box child tied to this weapon

	protected void Start()
	{
		_hitBox = GetComponentInChildren<HitBox>();
		_hitBox.attackDamage = attackDamage;
		_hitBox.hitForce = hitForce;
	}
}
