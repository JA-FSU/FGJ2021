using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatePlayerMovement : MonoBehaviour
{
    // Control management, I swear it needs to be like this for reasons.
    public string[] controls = new string[5]; // Left, Right, Jump, Crouch, Shoot
    // Variables for player movement and jump power.
    public float playerSpeed;
    public float jumpPower;
    // Are we on the ground? Are we trying to be prone?
    public bool grounded = true;
    public bool crouching = false;
    // Public sizing things, trust me we need them for crouching.
    public Vector3 defaultSize;
    public Vector3 crouchSize;
    private bool facingLeft = false;
    //Jonathan's code merged here.
    private GameManager gameManager;

    public GameObject bulletPrefab;
    public Transform bulletContainer;
    private GameObject spawner;
    public bool canShoot = true;
    private float Cooldown = 0.65f;

    public AudioClip jumpSound;
    public AudioClip shootSound;
    public AudioClip randomizeSound;

    private AudioSource soundFX;

    // Start is called before the first frame update
    void Start()
    {
        soundFX = GetComponent<AudioSource>();
        //Jonathan's code here.
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        spawner = GameObject.Find("BulletSpawner");
    }

    // Update is called once per frame
    void Update()
    {
        // Time to start checking for movement the hard way due to our convoluted controls. First the X axis.
        if (Input.GetKey(controls[0]))
        {
            transform.Translate(Vector2.left * Time.deltaTime * playerSpeed);
            facingLeft = true;
        }
        else if (Input.GetKey(controls[1]))
        {
            transform.Translate(Vector2.right * Time.deltaTime * playerSpeed);
            facingLeft = false;
        }
        //Now for jumping.
        if (Input.GetKeyDown(controls[2]) && grounded)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            soundFX.PlayOneShot(jumpSound, 1.0f);
            grounded = false;
        }
        // Aaand for crouching, we need to be grounded
        if (Input.GetKeyDown(controls[3]) && grounded)
        {
            transform.localScale = crouchSize;
            grounded = false;
            crouching = true;
        }
        if (crouching && Input.GetKeyUp(controls[3]))
        {
            transform.localScale = defaultSize;
            crouching = false;
            grounded = true;
        }
        if (Input.GetKeyDown(controls[4]) && canShoot && bulletContainer.childCount < 5 && gameManager.health > 0)
        {
            StartCoroutine("ShootWithCooldown");
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") && !crouching)
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        grounded = false;
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

        soundFX.PlayOneShot(randomizeSound, 1.0f);
    }

    IEnumerator ShootWithCooldown()
    {

        // trust me we need this line
        Quaternion rotationPos = spawner.transform.rotation;
        if (facingLeft)
        {
            rotationPos *= Quaternion.Euler (0f, 180f, 0f);
        }

        // Stuff before the delay
        Instantiate(bulletPrefab, spawner.transform.position, rotationPos, bulletContainer);
        canShoot = false;
        soundFX.PlayOneShot(shootSound, 1.0f);

        // The delay
        yield return new WaitForSeconds(Cooldown);

        // Stuff after the delay
        canShoot = true;
    }
}
