using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenuPanel;
    private bool isGamePaused = false;


    void Update()
    {
        
        if (Input.GetKey(KeyCode.Delete) && !isGamePaused)
        {
            pauseGame();
        }
        else if ((Input.GetKey(KeyCode.Escape) && isGamePaused)) 
        {
            resumeGame();
        }

    }


    private void pauseGame()
    {
        Time.timeScale = 0;
        pauseMenuPanel.SetActive(true);
        isGamePaused = true;
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        pauseMenuPanel.SetActive(false);
        isGamePaused = false;

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
