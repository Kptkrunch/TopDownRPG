using UnityEngine;

public class HitBox : MonoBehaviour
{ 
    IDamageable _hit;
    private DamageText _damageText;
    Vector2 _launchDirection;

    public int attackDamage;
    public float hitForce;
    public Vector2 totalForce;

    private void OnTriggerEnter2D(Collider2D other)
    {
        _damageText = GetComponentInChildren<DamageText>();
        _hit = other.GetComponent<IDamageable>();
        _launchDirection = (transform.position - other.transform.position).normalized;
        totalForce = _launchDirection * -hitForce;

        if (other.CompareTag("Enemy") && _hit != null)
        {
            _hit.TakeDamage(attackDamage);
            _hit.LaunchEnemy(totalForce);
            _damageText.Setup(attackDamage);
            _damageText.DisplayDamageText(other.transform.position);
        }
    }
}
