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
    public Queue<string> sentences;
    public Dialogos textosDialogos;
    
    void Start()
    {
        DialogueBox.SetActive(false);
        sentences = new Queue<string>();
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && dialogueActive)
        {
            if(DialogueBox.activeInHierarchy)
            {
                DialogueBox.SetActive(false);
            } else {
                DialogueBox.SetActive(true);
                DialogueText.GetComponent<Text>().text = dialogue;

                //sentences.Clear();
                //foreach(string sentence in textosDialogos.sentences) 
                //{
                   //sentences.Enqueue(sentence);
                   //DialogueText.GetComponent<Text>().text = sentence;
                  //Debug.Log(DialogueText.GetComponent<Text>().text);
                //}
            }
        }
    }
    

    //Esto comprueba que estas dentro del colider y activa el booleano
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


    //Esto ahora mismo no se esta usando, es para avanzar en los dialogos
    [System.Serializable]
    public class Dialogos 
    {
        [TextArea(3,10)]
        public string[] sentences;
    }

    
}
