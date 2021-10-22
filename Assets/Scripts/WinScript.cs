using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinScript : MonoBehaviour
{

    public GameObject WinText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine("WinTime");
        }
    }


    IEnumerator WinTime()
    {
        WinText.SetActive(true);
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("NateMainMenu");
    }
}
