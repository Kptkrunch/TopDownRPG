using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
	private TextMeshPro _textMesh;
	[SerializeField] private Transform damageTextPf;
	private string _damage;
	private void Awake()
	{
		_textMesh = transform.GetComponent<TextMeshPro>();
	}

	public void Setup(int dmg)
	{
		_damage = dmg.ToString();
		Debug.Log(_damage);
		_textMesh.SetText(_damage);
		Debug.Log(_textMesh.text);
	}

	public void DisplayDamageText(Vector2 location)
	{
		
		Debug.Log("display damage");
		var damageTransform = Instantiate(damageTextPf, location, Quaternion.identity);
		var damagePopup = damageTransform.GetComponent<DamageText>();
	}
}
