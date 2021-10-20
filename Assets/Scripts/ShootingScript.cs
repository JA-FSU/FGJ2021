using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    private GameObject spawner;

    float Cooldown;
    private float Reload = 0.65f;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("BulletSpawner");
    }

    // Update is called once per frame
    void Update()
    {
        Cooldown += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && Cooldown >= Reload)
        {
            Instantiate(bulletPrefab, spawner.transform.position, spawner.transform.rotation);
            Cooldown = 0;
        }
    }
}
