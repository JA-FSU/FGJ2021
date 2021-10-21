using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;
    public int health;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;

    public NatePlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore(0);
        health = 4;
        UpdateHealth(0);
        StartCoroutine("BeginChaos");
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

    IEnumerator BeginChaos()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            player.RandomizeControls(player.controls);
        }
        
    }
}
