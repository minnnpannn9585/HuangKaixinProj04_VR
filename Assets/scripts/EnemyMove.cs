using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Transform destination;
    public float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        destination = GameObject.FindGameObjectWithTag("Finish").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination.position, speed * Time.deltaTime);
        transform.LookAt(destination);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }
}
