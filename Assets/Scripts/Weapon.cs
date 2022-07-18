using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Weapon : MonoBehaviour
{
	public int damagePoints = 1;
	public float pushForce = 2.0f;
	private SpriteRenderer _spriteRenderer;
	private EdgeCollider2D _edgeCollider;

	protected void Start()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_edgeCollider = GetComponent<EdgeCollider2D>();
	}

	private void Update()
	{
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		
		Debug.Log("Trigger hit");
	}
}
