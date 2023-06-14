using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alfaMovimiento : MonoBehaviour
{

    public Transform checkSuelo;
    public bool enSuelo;
    public LayerMask capaSuelo;

    public float vel;
    Rigidbody2D rb;

    Vector3 escalaPric;
    Animator anim;


    [SerializeField]
    private float tiempoHastaSusto;

    private bool _susto;
    private float tiempoIdle;
    private float tiempoAsusta;

    [SerializeField] private AudioClip pasos;

    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        escalaPric = transform.localScale;

    }

    private void Update()
    {

        //Bloquear movimiento al caer
        if (!enSuelo)
        {
            vel = 0;
        }else if (enSuelo)
        {
            vel = 5;
        }

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

        if(h != 0) //si el personaje se est� moviendo, es decir, si h es 1 o -1
        {
            anim.SetBool("Andar", true);
            // Va horrible for some reason, audio de pasos --> SoundManager.Instance.PlaySound(pasos);
        }
        else //si el personaje est� quieto, es decir, h = 0
        {
            anim.SetBool("Andar", false);
        }
        anim.SetBool("enSuelo", enSuelo); 
        
    }

    //Detecta si el jugador est� en el suelo o no.
    private void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapCircle(checkSuelo.position, 0.25f, capaSuelo);
    }

}
