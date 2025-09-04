using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Rigidbody rd;
    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("");
    }

    // Update is called once per frame
    private void Update()
    {
        //rd.AddForce( Vector3.forward );//x,y,z   1,0,0

        float h = Input.GetAxisRaw("Horizontal"); // ad
        float v =Input.GetAxisRaw("Vertical");

        //Debug.Log(h);

        Vector3 dir = new Vector3(h, 0, v);
        rd.AddForce(dir*3);

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Enter" + collision.gameObject.name);
        
        if (collision.gameObject.tag == "food") 
        {
            Destroy(collision.gameObject );
        }
    }
}
