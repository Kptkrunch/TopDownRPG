using UnityEngine;

public class WeaponParent : MonoBehaviour
{
	public Vector2 PointerPosition { get; set; }
	private Vector3 _difference;
	private void Update()
	{
		PointToMouse();
		Debug.Log($"PointerPosition {PointerPosition}");
		//transform.right = (PointerPosition - (Vector2)transform.position).normalized;
	}
	
	private void PointToMouse()
	{
		Debug.Log(PointerPosition);

		if (Camera.main != null) _difference = Camera.main.ScreenToWorldPoint(PointerPosition) - transform.position;
		_difference.Normalize();
		float rotationZ = Mathf.Atan2(_difference.y, _difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
	}
}

