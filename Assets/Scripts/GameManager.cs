using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score;
    public int health;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore(0);
        health = 10;
        UpdateHealth(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void UpdateHealth(int healthToSubtract)
    {
        if (health > 0)
        {
            health -= healthToSubtract;
        }
        healthText.text = "Health: " + health;
    }
}
