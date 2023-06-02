using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambiarPiso : MonoBehaviour
{

    public int pisoActual = 1;
    public int[] Pisos = {0,1,2,3,4 };


    void Start()
    {


    }


    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

        }
    }
}
