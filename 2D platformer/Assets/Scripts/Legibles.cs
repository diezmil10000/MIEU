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
    // { 
    //     if(Input.GetKeyDown(KeyCode.Space) && dialogueActive)
    //     {
    //         if(DialogueBox.activeInHierarchy)
    //         {
    //             DialogueBox.SetActive(false);
    //         } else {
    //             DialogueBox.SetActive(true);

    //             foreach(string sentence in sentences)
    //             {           
    //                 DialogueText.GetComponent<Text>().text = sentence;
    //                 Debug.Log(sentence);
    //             }
    //         }
    //     }
    // } 
    //para comentar todo es Ctrl + K + C y para descomentarlo es Ctrl + K + U

    {
        if(Input.GetKeyDown(KeyCode.Space) && dialogueActive)
        {       
            numeroFrase = numeroFrase+1;
            if (numeroFrase >= sentences.Length)
            {
                DialogueBox.SetActive(false);
                Debug.Log("SE PASA");
                numeroFrase = -1;
            }else{
                DialogueBox.SetActive(true);
                DialogueText.GetComponent<Text>().text = sentences[numeroFrase];
                Debug.Log(sentences[numeroFrase]);
                Debug.Log(numeroFrase);
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

    //Esto hace que al irte del collider se quite el cuadro de texto
    void OnTriggerExit2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        { 
            dialogueActive = false; 
            DialogueBox.SetActive(false);
        }
    }
}
