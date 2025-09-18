using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{

    public GameObject foodParticle;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("food"))
        {
            Instantiate(foodParticle, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            
        }
    }
}
