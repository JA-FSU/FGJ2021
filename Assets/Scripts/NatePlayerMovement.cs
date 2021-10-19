using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatePlayerMovement : MonoBehaviour
{
    private string leftControl, rightControl, jumpControl, crouchControl, shootControl;
    public string[] controls = new string[5]; // Left, Right, Jump, Crouch, Shoot
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
        if (Input.GetKey(controls[0]))
        {
            transform.Translate(Vector2.left * Time.deltaTime * playerSpeed);
        }
        else if (Input.GetKey(controls[1]))
        {
            transform.Translate(Vector2.right * Time.deltaTime * playerSpeed);
        }
        //Now for jumping.
        if (Input.GetKeyDown(controls[2]) && grounded)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            grounded = false;
        }
        // Aaand for crouching, we need to be grounded
        if (Input.GetKeyDown(controls[3]) && grounded)
        {
            transform.localScale = new Vector3(1, 0.6f, 1);
        }
        if (!grounded || Input.GetKeyUp(controls[3]))
        {
            transform.localScale = Vector3.one;
        }


        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Randomizing controls!");
            RandomizeControls(controls);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }


    public void RandomizeControls(string[] controls) // Changes all the buttons at random.
    {
        // Knuth shuffle algorithm, many thanks to StackOverflow for suggesting it, and Wikipedia for supplying a generic codebase.
        for (int t=0; t < controls.Length; t++)
        {
            string temp = controls[t];
            int r = Random.Range(t, controls.Length);
            controls[t] = controls[r];
            controls[r] = temp;
        }

        
    }
}
