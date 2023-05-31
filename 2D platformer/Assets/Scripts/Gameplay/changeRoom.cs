using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeRoom : MonoBehaviour
{

    [SerializeField] GameObject player;
    public Image fade_Image;

    private bool isPlayerDetected = false;

    void Awake()
    {
        //Al cargar el programa preparamos la imagen para poder hacer los fades
        fade_Image.CrossFadeAlpha(0f, 0f, false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerDetected = true;
            Debug.Log("Te detect� vea");
            fade_Image.canvasRenderer.SetAlpha(0);
            //Fade in
            fade_Image.CrossFadeAlpha(1, 1f, false);
            
            //Fade out
            fade_Image.CrossFadeAlpha(0, 1.0f, false);

        }
    }

}
