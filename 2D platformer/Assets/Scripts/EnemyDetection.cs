using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemyDetection : MonoBehaviour
{

    private Animator anim;
    public GameObject target;
    public GameObject enemy;
    private Transform targetPos;

    private Vector2 currentPos;

    [SerializeField] private float acceleration = 1.0f;

    [SerializeField] private bool isPlayerDetected = false;

    private void Start()
    {

        targetPos = target.GetComponent<Transform>();
        currentPos = enemy.GetComponent<Transform>().position;

        anim = GetComponent<Animator>();

    }

    private void Update()
    {


    }

        private void OnTriggerStay2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player") 
        {
            isPlayerDetected = true;
            //Se mueve hacia el jugador
            transform.position = Vector2.MoveTowards(transform.position, targetPos.position, acceleration * Time.deltaTime);
            anim.SetBool("chasing", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerDetected = false;
            //Debug.Log("No te veo");

            //Se queda quieto
            transform.position = Vector2.MoveTowards(transform.position, currentPos, acceleration * Time.deltaTime);
            anim.SetBool("chasing", false);


        }
    }


}





