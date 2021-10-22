using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public int health;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public GameObject ignorer;
    public TextMeshProUGUI WinText;

    public NatePlayerMovement player;
    public AudioClip dying;
    AudioSource soundFX;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore(0);
        health = 4;
        UpdateHealth(0);
        StartCoroutine("BeginChaos");
        soundFX = GetComponent<AudioSource>();
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
        if (health == 0)
        {
            StartCoroutine("Lose");
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
    IEnumerator Lose()
    {
        GameObject.Find("Main Camera").transform.parent = null;
        soundFX.PlayOneShot(dying, 1.0f);
        Destroy(GameObject.Find("Player"));
        ignorer.SetActive(true);
        WinText.text = "Game Over!";
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("NateMainMenu");
    }
}
