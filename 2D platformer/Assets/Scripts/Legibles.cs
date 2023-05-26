using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Legibles : MonoBehaviour
{
    public GameObject DialogueBox;
    public GameObject DialogueText;
    public string dialogue;
    public bool dialogueActive;
    public string[] sentences;
    int numeroFrase;
    
    void Start()
    {
        numeroFrase = -1;
        DialogueBox.SetActive(false);
    }

    
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.E)) && dialogueActive)
        {       
            numeroFrase = numeroFrase+1;
            if (numeroFrase >= sentences.Length)
            {
                DialogueBox.SetActive(false);
                numeroFrase = -1;
            }else{
                DialogueBox.SetActive(true);
                DialogueText.GetComponent<Text>().text = sentences[numeroFrase];
            } 
        }
    }
    

    //Esto comprueba que estas dentro del collider y activa el booleano
    //y luego se usa como condicional arriba en el Update()
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        { 
            dialogueActive = true;
            
        }
    }

    //Esto hace lo contrario, asi que al salirte del collider se quita el cuadro de texto
    //y ademas se resetea el contador de frases para volver al principio
    void OnTriggerExit2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        { 
            dialogueActive = false; 
            DialogueBox.SetActive(false);
            numeroFrase = -1;
        }
    }
}
