using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Screens:")]
    [SerializeField] private GameObject gameScreen;
    [SerializeField] private GameObject menuScreen;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject settingsScreen;
    [Header("Managers:")]
    [SerializeField] private GameManager gameManager;
    [Header("BackGrouns:")]
    [SerializeField] public GameObject blackBackGround;
    [SerializeField] public GameObject whiteBackGround;
    [SerializeField] public GameObject blackBackGroundGame;
    [SerializeField] public GameObject whiteBackGroundGame;

    public void LoseScreen()
    {
        menuScreen.SetActive(false);
        gameScreen.SetActive(false);
        loseScreen.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("EternalLevel");
    }

    public void MenuScreen()
    {
        menuScreen.SetActive(true);
        gameScreen.SetActive(false);
        loseScreen.SetActive(false);
        settingsScreen.SetActive(false);
    }

    public void GameScreen()
    {
        menuScreen.SetActive(false);
        gameScreen.SetActive(true);
        loseScreen.SetActive(false);
        settingsScreen.SetActive(false);
    }
    public void SettingsScreen()
    {
        menuScreen.SetActive(false);
        gameScreen.SetActive(false);
        loseScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }

    public void Resume()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnMode()
    {
        blackBackGround.gameObject.SetActive(true);
        whiteBackGround.gameObject.SetActive(false);
        blackBackGroundGame.gameObject.SetActive(true);
        whiteBackGroundGame.gameObject.SetActive(false);
        SceneManager.LoadScene("EternalLevel");
    }

    public void OffMode()
    {
        blackBackGround.gameObject.SetActive(false);
        whiteBackGround.gameObject.SetActive(true);
        blackBackGroundGame.gameObject.SetActive(false);
        whiteBackGroundGame.gameObject.SetActive(true);
        SceneManager.LoadScene("EternalLevel");
    }

    public void ExitGames()
    {
        Application.Quit();
    }
}
