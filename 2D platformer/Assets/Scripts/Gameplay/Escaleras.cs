using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escaleras : MonoBehaviour
{
    private Transform destination;
    public float distance = 0.2f;

    public GameObject jugador;
    private Transform jugadorPos;

    public bool escaleraActive;



    void Start()
    {
        destination = GameObject.FindGameObjectWithTag("escalera").GetComponent<Transform>();
        jugador = GameObject.FindWithTag ("Player");
        jugadorPos = jugador.GetComponent<Transform>();
    }

    void Update()
    {
        if((Input.GetKeyDown(KeyCode.UpArrow) && escaleraActive) && jugadorPos.position.y < -10)
        {
            jugadorPos.position = new Vector2 (destination.position.x, destination.position.y+16);
        }

        if((Input.GetKeyDown(KeyCode.DownArrow) && escaleraActive) && jugadorPos.position.y > -60)
        {
            jugadorPos.position = new Vector2 (destination.position.x, destination.position.y-15);
        }
    }


    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        { 
            escaleraActive = true;
            destination = other.transform;
        }
    }

    void OnTriggerExit2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        { 
            escaleraActive = false; 
        }
    }
}
