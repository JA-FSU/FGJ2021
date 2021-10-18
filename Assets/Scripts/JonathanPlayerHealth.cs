using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JonathanPlayerHealth : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // When touching object with "Enemy" tag, subtract 1 from health
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (gameManager.health > 0)
            {
                Debug.Log("Touched enemy!");
                gameManager.UpdateHealth(1);
            }
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            return;
        }
    }
}
