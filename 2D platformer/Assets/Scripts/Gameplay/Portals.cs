using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Portals : MonoBehaviour
{
    private float distance = 0.2f;
    private float distance2 = 10f;
    
    private Transform izquierda;
    private Transform derecha;

    public Image fade_Image;

    void Awake()
    {
        //Al cargar el programa preparamos la imagen para poder hacer los fades
        fade_Image.CrossFadeAlpha(0f, 0f, false);
    }

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
    //El "< distance2 (10f)" es lo que hace que al acercarse se triggee
    //El "> distance (0.2f)" es lo que hace que no se vuelva a triggear de inmediato en el otro portal
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "fadein") {
            fade_Image.CrossFadeAlpha(1, 0.2f, false);
        }
        else if (Vector2.Distance(derecha.transform.position, other.transform.position) > distance && Vector2.Distance(derecha.transform.position, other.transform.position) < distance2)
        {
            other.transform.position = new Vector2(izquierda.position.x, izquierda.position.y);

            //Fade out
            if (other.tag == "Player") {
                fade_Image.CrossFadeAlpha(0, 0.4f, false);
            }
            
        }
        else if (Vector2.Distance(izquierda.transform.position, other.transform.position) > distance && Vector2.Distance(izquierda.transform.position, other.transform.position) < distance2)
        {
            other.transform.position = new Vector2(derecha.position.x, derecha.position.y);

            //Fade out
            if (other.tag == "Player") {
                fade_Image.CrossFadeAlpha(0, 0.4f, false);
            }
        }
    }

    //Este es para que si no sales de la sala pero has activado el fadein se te vaya al alejarte
    void OnTriggerExit2D (Collider2D other)
    {
        fade_Image.CrossFadeAlpha(0, 0.4f, false);
    }


}
