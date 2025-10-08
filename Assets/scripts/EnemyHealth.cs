using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;

    [HideInInspector]
    public int currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            //play vfx & sfx
            Destroy(gameObject);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rock"))
        {
            TakeDamage(1);
        }

        if (other.CompareTag("Arrow"))
        {
            TakeDamage(2);
        }
    }
}
