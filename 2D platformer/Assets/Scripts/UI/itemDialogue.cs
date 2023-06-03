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
        currentText = "Oye qué moderna ¿no?";
    }

    public void idAlfa()
    {
        currentText = "Tiene números y un código de barras que no entiendo, mira tú qué bien.";
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
        currentText = "Es azulón, qué cutre. Ojalá fuera moradito o algo.";
    }


}
