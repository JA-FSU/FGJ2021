using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Credits;
    public GameObject HowToPlay;

    public void Level1()
    {
        SceneManager.LoadScene("DomenicScene");
    }
    public void Level2() {
        SceneManager.LoadScene("DomenicScene2");
    }
    public void Level3()
    {
        SceneManager.LoadScene("DomenicScene3");
    }
    public void HowPlay()
    {
        MainMenu.SetActive(false);
        HowToPlay.SetActive(true);
    }
    public void Credit()
    {
        MainMenu.SetActive(false);
        Credits.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void WaitNoGoBack()
    {
        Credits.SetActive(false);
        HowToPlay.SetActive(false);
        MainMenu.SetActive(true);
    }
}
