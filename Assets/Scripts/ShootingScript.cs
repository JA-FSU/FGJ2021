using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    private GameManager gameManager;

    public GameObject bulletPrefab;
    public Transform bulletContainer;
    private GameObject spawner;
    public bool canShoot = true;
    private float Cooldown = 0.65f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        spawner = GameObject.Find("BulletSpawner");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canShoot && bulletContainer.childCount < 5 && gameManager.health > 0)
        {
            StartCoroutine("ShootWithCooldown");
        }
    }

    IEnumerator ShootWithCooldown()
    {
        // Stuff before the delay
        Instantiate(bulletPrefab, spawner.transform.position, spawner.transform.rotation, bulletContainer);
        canShoot = false;

        // The delay
        yield return new WaitForSeconds(Cooldown);

        // Stuff after the delay
        canShoot = true;
    }

}
