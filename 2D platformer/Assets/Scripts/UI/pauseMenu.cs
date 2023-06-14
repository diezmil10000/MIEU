using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject fadePanel;
    private bool isGamePaused = false;


    void Update()
    {
        
        if ((Input.GetKeyDown(KeyCode.Delete) || Input.GetKeyDown(KeyCode.Escape)) && !isGamePaused)
        {
            pauseGame();
        }
        else if ((Input.GetKeyDown(KeyCode.Delete) || Input.GetKeyDown(KeyCode.Escape)) && isGamePaused) 
        {
            resumeGame();
        }

    }


    private void pauseGame()
    {
        Time.timeScale = 0;
        pauseMenuPanel.SetActive(true);
        isGamePaused = true;
        fadePanel.SetActive(false);
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        pauseMenuPanel.SetActive(false);
        isGamePaused = false;
        fadePanel.SetActive(true);


    }

    public void salir() 
    {
        Application.Quit();
    }

    public void returnMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }


}
