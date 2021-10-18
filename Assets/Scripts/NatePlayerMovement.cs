using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatePlayerMovement : MonoBehaviour
{
    public string leftControl, rightControl, jumpControl, crouchControl, shootControl;
    public string[] defaultControls = new string[5];
    public float playerSpeed;
    public float jumpPower;

    public bool grounded = true;
    public Vector3 defaultSize;
    public Vector3 crouchSize;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Time to start checking for movement the hard way due to our convoluted controls. First the X axis.
        if (Input.GetKey(leftControl))
        {
            transform.Translate(Vector2.left * Time.deltaTime * playerSpeed);
        }
        else if (Input.GetKey(rightControl))
        {
            transform.Translate(Vector2.right * Time.deltaTime * playerSpeed);
        }
        //Now for jumping.
        if (Input.GetKeyDown(jumpControl) && grounded)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            grounded = false;
        }
        // Aaand for crouching, we need to be grounded
        if (Input.GetKeyDown(crouchControl) && grounded)
        {
            transform.localScale = new Vector3(1, 0.6f, 1);
        }
        if (!grounded || Input.GetKeyUp(crouchControl))
        {
            transform.localScale = Vector3.one;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
