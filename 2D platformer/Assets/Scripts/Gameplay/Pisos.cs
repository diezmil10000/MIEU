using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pisos : MonoBehaviour
{
    int[] numeroPisos = new int[5];
    public int pisoActual;
    float altura;

    public Transform[] escalerasArray;

    void Start()
    {
        pisoActual = 1;
    }

    
    void Update()
    {
        altura = GameObject.FindWithTag ("Player").GetComponent<Transform>().position.y;
        if (Input.GetKeyDown(KeyCode.Space)){
            Debug.Log(pisoActual);
        }
        

        if (altura > -6f) {
            pisoActual = 4;
        } else if (altura < -6f && altura > -22f) {
            pisoActual = 3;
        } else if (altura < -22f && altura > -38f) {
            pisoActual = 2;
        } else if (altura < -35f && altura > -55f) {
            pisoActual = 1;
        } else if (altura < -55f && altura > -80f) {
            pisoActual = 0;
        } else if (altura < -80f){
            pisoActual = -1;
        }
    }

    void cambioPiso()
    
    {
        
    }
}
