using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public int playerTurn = 1;

    [HideInInspector]
    public int playerWon;
    [HideInInspector]
    public bool canWin = true;

    public GameObject pauseMenu;
    private bool pause;

    public static GameManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        pause = false;
        pauseMenu.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
        print("Quit");
    }

    public void TogglePauseMenu()
    {
        pause = !pause;
        if(pause == true)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }

    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void ResumeGame()
    {
        pause = false;

        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
