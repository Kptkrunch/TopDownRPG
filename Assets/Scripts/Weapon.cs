using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
	public int damagePoint = 1;
	public float pushForce = 2.0f;
	
	// upgrade
	public int weaponLevel = 0;
	private SpriteRenderer _spriteRenderer;
	
	// Swing
	private float cooldown = .5f;
	private float lastSwing;

	protected void Start()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
	}

	protected void Update()
	{
		if (Keyboard.current.spaceKey.wasPressedThisFrame)
		{
			if (Time.time - lastSwing > cooldown)
			{
				lastSwing = Time.time;
				Swing();
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			// collision.gameObject.SendMessage("ApplyDamage", 10);
			Debug.Log("Wap!!!");
		}
	}

	private void Swing()
	{
		print("Woosh woosh woosh");
	}

}
