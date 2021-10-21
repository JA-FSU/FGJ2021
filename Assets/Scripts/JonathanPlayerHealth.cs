using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JonathanPlayerHealth : MonoBehaviour
{
    private GameManager gameManager;
    Rigidbody2D playerRb;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerRb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // When touching object with "Enemy" tag, subtract 1 from health
        if (other.gameObject.CompareTag("Enemy"))
        {
            Vector2 awayFromPlayer = gameObject.transform.position - other.transform.position;

            playerRb.velocity = Vector2.zero;
            playerRb.AddForce(awayFromPlayer * 4, ForceMode2D.Impulse);
            if (gameManager.health > 0)
            {
                gameManager.UpdateHealth(1);
            }
        
        }
    }
}
