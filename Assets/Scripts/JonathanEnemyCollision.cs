using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JonathanEnemyCollision : MonoBehaviour
{
    private GameManager gameManager;
    Rigidbody2D enemyRb;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        enemyRb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            gameManager.UpdateScore(5);
        }
    }
}
