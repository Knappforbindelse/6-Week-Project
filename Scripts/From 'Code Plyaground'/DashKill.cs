using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashKill : MonoBehaviour
{
    public int maxHealth = 1;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;  
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
