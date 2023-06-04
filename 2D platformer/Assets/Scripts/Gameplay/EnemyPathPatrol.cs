using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathPatrol : MonoBehaviour {

    private Animator anim;
    public GameObject target;
    public GameObject enemy;

	public Transform[] waypoints;
    int waypointIndex = 0;

	private int speed = 4;
    private float acceleration = 1.2f;
    private bool isPlayerDetected = false;
    private Transform targetPos;


    public InteractionSystem armario;

	void Start () 
    {
        target = GameObject.FindWithTag ("Player");
        targetPos = target.GetComponent<Transform>();

        anim = GetComponent<Animator>();
	}

	void Update () 
    {
        if (isPlayerDetected == true)
        {
            Chase ();

            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.E)) && armario.dentroarmario == true)
            {
                waypointIndex += 1;
                Debug.Log(waypointIndex);
                Move();
                isPlayerDetected = false;
            }  
               
        }else{
            Move();
        }
    }

	void Move() 
	{
		if (waypointIndex == waypoints.Length)
        {
			waypointIndex = 0;
        }
        else {
            transform.position = Vector3.MoveTowards (transform.position, waypoints[waypointIndex].transform.position, speed * Time.deltaTime);											
            anim.SetBool("chasing", false);
        }

	}

    void Chase()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos.position, acceleration * speed * Time.deltaTime);
        anim.SetBool("chasing", true);
    }

    //Esto comprueba que estas dentro del collider y activa el booleano del Update()
    //pero solo te lo activa si estas fuera del armario
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player") && armario.dentroarmario == false)
        { 
            isPlayerDetected = true;
        }
    }

}