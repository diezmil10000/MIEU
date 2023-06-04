using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Escaleras : MonoBehaviour
{
    Transform destination;
    Transform jugadorPos;
    float distance = 0.2f;

    bool escaleraActive;

    public Image fade_Image;

    public Pisos piso;

    void Awake()
    {
        //Al cargar el programa preparamos la imagen para poder hacer los fades
        fade_Image.CrossFadeAlpha(0f, 0f, false);
    }

    void Start()
    {
        jugadorPos = GameObject.FindWithTag ("Player").GetComponent<Transform>();
    }

    void Update()
    {
        
        if((Input.GetKeyDown(KeyCode.UpArrow) && escaleraActive) && piso.pisoActual <  4)
        {
            Debug.Log(piso.pisoActual);
            destination = piso.escalerasArray[piso.pisoActual+1];

            jugadorPos.position = new Vector2 (destination.position.x+4, destination.position.y-1f);
            fade_Image.CrossFadeAlpha(1, 0f, false);
            fade_Image.CrossFadeAlpha(0, 1f, false);
        }

        if((Input.GetKeyDown(KeyCode.DownArrow) && escaleraActive) && piso.pisoActual >  0)
        {
            Debug.Log(piso.pisoActual);
            destination = piso.escalerasArray[piso.pisoActual-1];
            
            jugadorPos.position = new Vector2 (destination.position.x+4, destination.position.y-1f);
            fade_Image.CrossFadeAlpha(1, 0f, false);
            fade_Image.CrossFadeAlpha(0, 1f, false);
        }
    }

    //Esto comprueba que estas dentro del collider y activa el booleano
    //y luego se usa como condicional arriba en el Update()
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        { 
            escaleraActive = true;
        }
    }

    //Esto hace lo contrario, desactiva el booleano
    void OnTriggerExit2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        { 
            escaleraActive = false; 
        }
    }
}
