
using UnityEngine;

public class HealthSystem
{
	private int _health;
	private int _maxHealth;
	private int _damage;
	private int _heal;

	public HealthSystem(int health)
	{
		this._health = health;
	}

	public int GetHealth()
	{
		Debug.Log($"Health: {_health}");
		return _health;
	}

	public void TakeDamage(int dmg)
	{
		_health -= _health - _damage;
		if (_health < 0)
		{
			_health = 0;
		}
		Debug.Log(dmg);
	}

	public void HealDamage(int heal)
	{
		_health += _health + heal;
		if (_health > _maxHealth)
		{
			_health = _maxHealth;
		}
	}
}