using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alfaMovimiento : MonoBehaviour
{
    
    public float vel = 5.0f;
    Rigidbody2D rb;

    Vector3 escalaPric;
    Animator anim;


    [SerializeField]
    private float tiempoHastaSusto;

    private bool _susto;
    private float tiempoIdle;
    private float tiempoAsusta;

    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        escalaPric = transform.localScale;

        _susto = false;

    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal") * vel;

        rb.velocity = new Vector2(h, rb.velocity.y);

        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(-escalaPric.x, escalaPric.y, escalaPric.z);
           
        }else if(rb.velocity.x < 0) 
        {
            transform.localScale = escalaPric;
        }

        //ANIMACIONES

        if(h != 0) //si el personaje se está moviendo, es decir, si h es 1 o -1
        {
            anim.SetBool("Andar", true);
        }
        else //si el personaje está quieto, es decir, h = 0
        {
            anim.SetBool("Andar", false);
        }
        anim.SetBool("enSuelo", true); //Alfa siempre esta tocando el suelo
        anim.SetBool("susto", _susto);

        //Susto
        if(_susto == false)
        {
            tiempoIdle += Time.deltaTime;

            if(tiempoIdle > tiempoHastaSusto) 
            {
                _susto = true;
                tiempoAsusta += Time.deltaTime;
            }
        }else if (tiempoAsusta >= 2)
        {
            ResetIdle(anim);
        }
        
    }


    private void ResetIdle(Animator animator)
    {

        _susto = false;
        tiempoIdle = 0;
        tiempoAsusta = 0;

    }



}
