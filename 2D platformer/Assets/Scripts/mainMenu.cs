using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

    public GameObject settings;
    public GameObject menu;


    public void Jugar() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Ajustes()
    {
        irAjustes();
    }

    public void Salir()
    {
        Debug.Log("Salir");
        Application.Quit();
    }

    public void Volver() 
    {
        irAtras();
    }

    private void irAtras()
    {
        settings.SetActive(false);
        menu.SetActive(true);
    }

    private void irAjustes()
    {
        settings.SetActive(true);
        menu.SetActive(false);
    }

}
