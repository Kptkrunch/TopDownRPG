using UnityEngine;

public class TestingFloatingText : MonoBehaviour
{
	[SerializeField] private Transform pfDamagePopup;

	private void Start()
	{
		Transform damagePopupTransform = Instantiate(pfDamagePopup, Vector3.zero, Quaternion.identity);
		DamageText damageText = damagePopupTransform.GetComponent<DamageText>();
	}
}
