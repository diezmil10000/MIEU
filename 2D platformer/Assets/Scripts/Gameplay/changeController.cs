using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class changeController : MonoBehaviour
{

    public Pisos pisos;

   private Animator animator;

   public RuntimeAnimatorController rojo;
   public RuntimeAnimatorController amarillo;
   public RuntimeAnimatorController azul;
   public RuntimeAnimatorController verde;

    // Use this for initialization
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pisos.pisoActual == 0)
        {
            animator.runtimeAnimatorController = amarillo;
        }
        else if (pisos.pisoActual == 1)
        {
            animator.runtimeAnimatorController = verde;
        }
        else if (pisos.pisoActual == 2 || pisos.pisoActual ==4)
        {
            animator.runtimeAnimatorController = rojo;
        }
        else if (pisos.pisoActual == 3 || pisos.pisoActual == -1)
        {
            animator.runtimeAnimatorController = azul;
        }

    }
}