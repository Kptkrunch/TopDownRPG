using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Update = Unity.VisualScripting.Update;

public class Enemy : MonoBehaviour, IDamageable
{
	private int _enemyHealth = 20;
	private int _enemyMaxHealth = 20;
	private bool _isDead;
	private Animator _animator;

	private void Start()
	{
		_isDead = false;
		_animator = GetComponentInChildren<Animator>();
	}

	private void Update()
	{
		if (_isDead)
		{
			_animator.SetTrigger("isDead");
			Debug.Log("oof I'm dead");
			Destroy(gameObject, .5f);
		}
	}

	public void TakeDamage(int dmg)
	{
		_enemyHealth -= dmg;
		if (_enemyHealth < 0)
		{
			_enemyHealth = 0;
			_isDead = true;
		}
		Debug.Log($"ouch I took {dmg} damage");
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
	
}


