using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Agujeros : MonoBehaviour
{
    private Transform destination;
    public float distance = 0.2f;
    public Pisos piso;

    void Start()
    {
        
    }

    void Update()
    {
        if (piso.pisoActual < 3)
        {
            destination = GameObject.FindGameObjectWithTag("agujero").GetComponent<Transform>();
        } else {
            destination = GameObject.FindGameObjectWithTag("agujero2").GetComponent<Transform>();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && Vector2.Distance(transform.position, other.transform.position) > distance)
        {
            other.transform.position = new Vector2 (destination.position.x, destination.position.y-8);
        }

    }

}
