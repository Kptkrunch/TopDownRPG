using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
	public int hitpoints = 10;
	public int maxHitPoints = 10;
	public float pushRecoverySpeed = .2f;

	protected float immuneTime = 1.0f;
	protected float lastImmune;

	protected Vector3 pushDirection;

	protected virtual void ReceiveDamage(Damage dmg)
	{
		if (Time.time - lastImmune > immuneTime)
		{
			lastImmune = Time.time;
			hitpoints -= dmg.damageAmount;
			pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;
				
			//instance.ShowText(dmg.damageAmount.ToString(), 15, Color.red, transform.position, Vector3.zero, 0.5f);
			
			if (hitpoints <= 0)
			{
				hitpoints = 0;
				Death();
			}
		}
	}

	protected virtual void Death()
	{
		
	}
}


