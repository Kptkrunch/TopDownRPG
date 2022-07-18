using UnityEngine;

public class Enemy : MonoBehaviour
{

    public HealthSystem healthSystem;
    // Start is called before the first frame update
    void Start()
    {
        healthSystem = new HealthSystem(20);
    }

    // Update is called once per frame
    void Update()
    {
        //healthSystem.GetHealth();
    }
    
}
