using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestinationMana : MonoBehaviour
{
    public static DestinationMana instance;
    public float timer = 150.0f;
    public Text timeText;
    public Text scoreText;

    public int playerHealth = 5;
    public int totalScore = 0;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timeText.text = "Time's Up!";
            // You can add additional logic here for when the timer reaches zero
        }
        else
        {
            int minutes = Mathf.FloorToInt(timer / 60f);
            int seconds = Mathf.FloorToInt(timer % 60f);
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void AddScore(int score)
    {
        totalScore += score;
        scoreText.text =   totalScore.ToString();
    }
}
