using UnityEngine;

public interface IDamageable
{
	void HealDamage(int healAmount);
	void TakeDamage(int damageAmount);
	void LaunchEnemy(Vector2 launchDirection, int launchPower);
}
