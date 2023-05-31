using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour
{
    public float distance = 0.2f;
    public float distance2 = 10f;
    public Transform izquierda;
    public Transform derecha;

    void Start()
    {
        DosPortales();
    }

    public void DosPortales()
    {
        izquierda = this.gameObject.transform.GetChild(0);
        derecha = this.gameObject.transform.GetChild(1);
    }

    //Si un collider toca el portal, se coge su posicion del transform y se cambia al otro portal
    //Le puse el condicional de las tags porque si no se buggea el campo de vision del bicho
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(Vector2.Distance(izquierda.transform.position, other.transform.position));
        Debug.Log(Vector2.Distance(derecha.transform.position, other.transform.position));

        if ((other.tag == "Player" || other.tag == "Enemy") && Vector2.Distance(izquierda.transform.position, other.transform.position) > distance && Vector2.Distance(izquierda.transform.position, other.transform.position) < distance2)
        {
            other.transform.position = new Vector2 (derecha.position.x, derecha.position.y);

        }else if ((other.tag == "Player" || other.tag == "Enemy") && Vector2.Distance(derecha.transform.position, other.transform.position) > distance && Vector2.Distance(derecha.transform.position, other.transform.position) < distance2)
        {
            other.transform.position = new Vector2 (izquierda.position.x, izquierda.position.y);
        }
    }


}
