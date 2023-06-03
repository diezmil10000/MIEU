using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Portals : MonoBehaviour
{
    public float distance = 0.2f;
    public float distance2 = 10f;
    public Transform izquierda;
    public Transform derecha;


    //fade
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

    private void fadeOut()
    {
        //Fade out
        fade_Image.CrossFadeAlpha(0, 0.4f, false);
    }

    //Si un collider toca el portal, se coge su posicion del transform y se cambia al otro portal
    //Le puse el condicional de las tags porque si no se buggea el campo de vision del bicho
    void OnTriggerEnter2D(Collider2D other)
    {
       
        if ((other.tag == "Player") && Vector2.Distance(derecha.transform.position, other.transform.position) > distance && Vector2.Distance(derecha.transform.position, other.transform.position) < distance2)
        {
            other.transform.position = new Vector2(izquierda.position.x, izquierda.position.y);

            //Fade in
            fade_Image.CrossFadeAlpha(1, 0.2f, false);
            Invoke("fadeOut", 0.3f);
        }
        else if ((other.tag == "Player") && Vector2.Distance(izquierda.transform.position, other.transform.position) > distance && Vector2.Distance(izquierda.transform.position, other.transform.position) < distance2)
        {
            other.transform.position = new Vector2(derecha.position.x, derecha.position.y);

            //Fade in
            fade_Image.CrossFadeAlpha(1, 0.2f, false);
            Invoke("fadeOut", 0.3f);
        }
        else if ((other.tag == "Player" || other.tag == "Enemy") && Vector2.Distance(izquierda.transform.position, other.transform.position) > distance && Vector2.Distance(izquierda.transform.position, other.transform.position) < distance2)
        {
            other.transform.position = new Vector2(derecha.position.x, derecha.position.y);


        }
        else if ((other.tag == "Player" || other.tag == "Enemy") && Vector2.Distance(derecha.transform.position, other.transform.position) > distance && Vector2.Distance(derecha.transform.position, other.transform.position) < distance2)
        {
            other.transform.position = new Vector2(izquierda.position.x, izquierda.position.y);
        }
    }


}
