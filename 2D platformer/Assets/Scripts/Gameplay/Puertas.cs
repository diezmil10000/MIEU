using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puertas : MonoBehaviour
{
    Transform destination;
    Transform jugadorPos;

    private Transform puertaEntrada;
    private Transform puertaSalida;

    bool puertaActive;

    public Image fade_Image;

    void Awake()
    {
        //Al cargar el programa preparamos la imagen para poder hacer los fades
        fade_Image.CrossFadeAlpha(0f, 0f, false);
    }

    void Start()
    {
        DosPortales();
        jugadorPos = GameObject.FindWithTag ("Player").GetComponent<Transform>();
    }

    public void DosPortales()
    {
        puertaEntrada = this.gameObject.transform.GetChild(0);
        puertaSalida = this.gameObject.transform.GetChild(1);
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.E)) && puertaActive)
        {
            jugadorPos.position = new Vector2 (destination.position.x, destination.position.y);
        }
    }


    //Esto comprueba que estas dentro del collider y activa el booleano
    //y luego se usa como condicional arriba en el Update()
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        { 
            puertaActive = true;
        }

        //esto compara en que puerta se situa el jugador
        //la que esta mas abajo, a menor posicion Y, es la de salida
        //asi que su destino es la de entrada
        if (other.transform.position.y < -80) {
            destination = puertaEntrada;
        } else {
            destination = puertaSalida;
        }
    }

    //Esto hace lo contrario, desactiva el booleano
    void OnTriggerExit2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        { 
            puertaActive = false; 
        }
    }
}
