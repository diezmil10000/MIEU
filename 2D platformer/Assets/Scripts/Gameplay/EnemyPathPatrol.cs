using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathPatrol : MonoBehaviour {

    private Animator anim;
    public GameObject target;
    public GameObject enemy;

	public Transform[] waypoints;
    int waypointIndex = 0;

	public int speed = 3;
    public float acceleration = 2.0f;
    private bool isPlayerDetected = false;
    private Transform targetPos;

    public InteractionSystem armario;

	void Start () 
    {
        targetPos = target.GetComponent<Transform>();

        anim = GetComponent<Animator>();

		transform.position = waypoints [waypointIndex].transform.position;
	}

	void Update () 
    {
        if (isPlayerDetected == true)
        {
            Chase ();
            if (armario.dentroarmario == true)
            {
                Move();
                isPlayerDetected = false;
            }
        }else{
            Move();
        }
    }

	void Move()
	{
		transform.position = Vector3.MoveTowards (transform.position, waypoints[waypointIndex].transform.position, speed * Time.deltaTime);											
		anim.SetBool("chasing", false);

		if (transform.position == waypoints [waypointIndex].transform.position) {
			waypointIndex += 1;
		}
				
		if (waypointIndex == waypoints.Length)
			waypointIndex = 0;
	}

    void Chase()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos.position, acceleration * speed * Time.deltaTime);
        anim.SetBool("chasing", true);
    }

    //Esto comprueba que estas dentro del collider y activa el booleano del Update()
    //pero solo te lo activa si estás fuera del armario
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player") && armario.dentroarmario == false)
        { 
            isPlayerDetected = true;
        }
    }

}