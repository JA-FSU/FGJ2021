using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JonathanBulletMove : MonoBehaviour
{
    private float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        // Destroy out of bounds
        if (transform.position.x > 11 || transform.position.x < -11)
        {
            Destroy(gameObject);
        }
    }
}
