using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;

    [HideInInspector]
    public int currentHealth;

    public int score;
    
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
            DestinationMana.instance.AddScore(score);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rock"))
        {
            Instantiate(Resources.Load("EnemyDeathVFX"), transform.position, Quaternion.identity);
            TakeDamage(1);
        }

        if (other.CompareTag("Arrow"))
        {
            Instantiate(Resources.Load("ArrowHit01"), transform.position, Quaternion.identity);
            TakeDamage(2);
        }
        if(other.CompareTag("BigArrow"))
        {
            Instantiate(Resources.Load("ArrowHit02"), transform.position, Quaternion.identity);
            TakeDamage(3);
        }
    }
}
