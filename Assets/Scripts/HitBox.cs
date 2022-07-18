using UnityEngine;

public class HitBox : MonoBehaviour
{ 
    IDamageable hit;
    
    Vector2 _enemyPosition; 
    Vector2 _hitboxPosition;
    Vector2 _launchDirection;

    public int attackDamage;
    public int hitForce;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(hitForce);
        Debug.Log(attackDamage);
        _enemyPosition = other.transform.position;
        _hitboxPosition = gameObject.transform.position;
        _launchDirection = (_hitboxPosition - _enemyPosition).normalized;
        hit = other.GetComponent<IDamageable>();

        Debug.Log($"launch angle: {_launchDirection}");
        if (other.CompareTag("Enemy") && hit != null)
        {
            hit.TakeDamage(attackDamage);
            hit.LaunchEnemy(_launchDirection, hitForce);
            
        }
    }
}
