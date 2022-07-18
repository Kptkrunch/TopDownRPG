using UnityEngine;

public class Slime : MonoBehaviour, IDamageable
{
	private HealthSystem _healthSystem;
	public int enemyHealth = 20;
	private void Start()
	{
		_healthSystem = new HealthSystem(enemyHealth);
	}
	public void HealDamage(int dmg)
	{
		Debug.Log($"health restored{dmg}");
		_healthSystem.HealDamage(dmg);
	}
	public void TakeDamage(int dmg)
	{
		Debug.Log(dmg);
		_healthSystem.TakeDamage(dmg);
	}
}


