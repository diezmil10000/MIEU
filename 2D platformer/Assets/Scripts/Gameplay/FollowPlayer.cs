using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;

    [SerializeField] private float y = 2.0f;
    [SerializeField] private float z = -2.5f;

    public Vector3 offset;


    // Update is called once per frame
    void Update()
    {
        //Seguir al jugador

        if (player.position.x >= -82.5 && player.position.x <= -54 || player.position.x >-25 && player.position.x <= 8 || player.position.x > 38 && player.position.x <= 71)
        {
            transform.position = player.transform.position + new Vector3(0, y - 0.15f, z);
        }
        //Transportamos la camara al otro lado del portal
        else if (player.position.x > -48 && player.position.x < - 25 && Input.GetKey(KeyCode.RightArrow)) 
        {
            transform.position = new Vector3(-25, player.position.y + 1.85f, z);
        }
        else if (player.position.x > -48 && player.position.x < -35 && Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(-54, player.position.y + 1.85f, z);
        }
        else if (player.position.x > 15 && player.position.x < 30 && Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3(38, player.position.y + 1.85f, z);
        }
        else if (player.position.x > 15 && player.position.x < 30 && Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(8, player.position.y + 1.85f, z);
        }
        else //Solo muevo la cámara en y
        {
            Vector3 position = transform.position;
            //Cojo la posición del jugador en y, además le sumo una pequeña corrección para que la cámara no quede muy baja.
            position.y = (player.position + offset).y +1.85f; 
            transform.position = position;
        }
    }
}
