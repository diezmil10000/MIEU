using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class itemDialogue : MonoBehaviour
{

    [SerializeField] private Text itemText;
    private string currentText;


    private void Update()
    {
        itemText.text = currentText;
    }

    public void tablet()
    {
        currentText = "Oye qu� moderna �no?";
    }

    public void idAlfa()
    {
        currentText = "Tiene n�meros y un c�digo de barras que no entiendo, mira t� qu� bien.";
    }

    public void cajaTabaco()
    {
        currentText = "Es mi marca favorita, pero no quedan cigarros.";
    }
    public void mechero()
    {
        currentText = "Jo, ahora me apetece un cigarrito.";
    }
    public void boli()
    {
        currentText = "Es azul�n, qu� cutre. Ojal� fuera moradito o algo.";
    }


}
