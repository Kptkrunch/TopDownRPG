using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Other hit");
            Debug.Log($"this is the other object {other.ToString()}");
            other.attachedRigidbody.AddForce(2f * other.attachedRigidbody.velocity);
        }
    }
}
