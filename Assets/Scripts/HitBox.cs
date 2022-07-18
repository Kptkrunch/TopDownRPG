using UnityEngine;

public class HitBox : MonoBehaviour
{
  
    private void OnTriggerStay2D(Collider2D other)
    {
        IDamageable hit = other.GetComponent<IDamageable>();
        if (other.CompareTag("Enemy") && hit != null)
        {
            Debug.Log($"this is the other object {hit}");
            //other.SendMessage("TakeDamage", 10);
            hit.TakeDamage(10);
            hit.HealDamage(5);

        }
    }
}
