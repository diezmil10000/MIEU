using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject creditos;


    public void Jugar() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Ajustes()
    {
        irAjustes();
    }

    public void Creditos() 
    {
        irCreditos();
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
        creditos.SetActive(false);
        settings.SetActive(false);
        menu.SetActive(true);
    }

    private void irAjustes()
    {
        settings.SetActive(true);
        menu.SetActive(false);
    }

    private void irCreditos() 
    {
        creditos.SetActive(true);
        menu.SetActive(false);
    }

}
