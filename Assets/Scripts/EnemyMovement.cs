using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    int jumpForce = 6;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnBecameVisible()
    {
        rb.isKinematic = false;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
}
