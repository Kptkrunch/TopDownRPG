using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
	private int _enemyHealth = 20;
	private int _enemyMaxHealth = 20;
	private bool _isDead;
	private Animator _animator;
	private Rigidbody2D _enemyRb2D;
	private DamageText _damageText;

	private void Awake()
	{
		_isDead = false;
		_animator = GetComponentInChildren<Animator>();
		_enemyRb2D = GetComponent<Rigidbody2D>();
		_damageText = gameObject.AddComponent<DamageText>();
	}

	private void Update()
	{
		if (_isDead)
		{
			_animator.SetTrigger("isDead");
			Debug.Log("bloop bloop POP!!!......DEAD!!");
			Destroy(gameObject, .5f);
		}
	}

	public void TakeDamage(int dmg)
	{
		Debug.Log($"incoming Damage: {dmg}");
		if (_enemyHealth < 0)
		{
			_enemyHealth = 0;
			_isDead = true;
		} 
	}
	
	public void HealDamage(int heal)
	{
		_enemyHealth += heal;
		if (_enemyHealth > _enemyMaxHealth)
		{
			_enemyHealth = _enemyMaxHealth;
		}
		Debug.Log($"Ahhhh much better, you were healed for {heal} health");
	}

	public void LaunchEnemy(Vector2 force)
	{
		_enemyRb2D.AddForce(force, ForceMode2D.Impulse);
	}

	public void Setup(int dmg)
	{
		_damageText.Setup(dmg);
		_damageText.DisplayDamageText(transform.position);
		Debug.Log($"setup completed");
	}
}


