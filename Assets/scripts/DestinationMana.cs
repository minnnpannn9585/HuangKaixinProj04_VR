using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestinationMana : MonoBehaviour
{
    public float timer = 150.0f;
    public Text timeText;

    public int playerHealth = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timeText.text = "Time's Up!";
            // You can add additional logic here for when the timer reaches zero
        }
        else
        {
            timeText.text = "Time: " + Mathf.Round(timer).ToString();
        }
    }
}
