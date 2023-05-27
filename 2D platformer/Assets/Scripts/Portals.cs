using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour
{
    private Transform destination;
    public bool isOrange;
    public float distance = 0.2f;

    void Start()
    {
        if (isOrange == false)
        {
            destination = GameObject.FindGameObjectWithTag("orange portal").GetComponent<Transform>();
        } else {
            destination = GameObject.FindGameObjectWithTag("blue portal").GetComponent<Transform>();
        }
    }

    //Si un collider toca el portal, se coge su posicion del transform y se cambia al otro portal
    //Le puse el condicional de las tags porque si no se buggea el campo de vision del bicho
    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.tag == "Player" || other.tag == "Enemy") && Vector2.Distance(transform.position, other.transform.position) > distance)
        {
            other.transform.position = new Vector2 (destination.position.x, destination.position.y);
        }
    }
}
