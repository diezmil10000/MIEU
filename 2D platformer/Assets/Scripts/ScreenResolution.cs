using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenResolution : MonoBehaviour
{

    private List<int> widthList = new List<int>();
    private List<int> heightList = new List<int>();

    public int resolutionIndex;
    public int width;
    public int height;
    public bool fullScreen;

    public Text resObj;
    public Text timer;

    public GameObject Opciones;
    public GameObject Confirmar;

    public int tiempoConfirmacion;

    void Start()
    {

        fullScreen = true;

        Resolution[] resolutions = Screen.resolutions;

        foreach (var res in resolutions)
        {
            widthList.Add(res.width);
            heightList.Add(res.height);

        }

        resolutionIndex = widthList.Count - 1;

        width = widthList[resolutionIndex];
        height = heightList[resolutionIndex];

        Screen.SetResolution(width, height, fullScreen);
    }

    public void siguienteRes()
    {
        resolutionIndex++;
        if (resolutionIndex > widthList.Count - 1)
        {
            resolutionIndex = 0;
        }
        resObj.text = widthList[resolutionIndex] + "x" + heightList[resolutionIndex];
    }

    public void anteriorRes()
    {
        resolutionIndex--;
        if (resolutionIndex < 0)
        {
            resolutionIndex = widthList.Count - 1;
        }
        resObj.text = widthList[resolutionIndex] + "x" + heightList[resolutionIndex];
    }

    public void aplicarResolucion(int timeCount)
    {
        Screen.SetResolution(widthList[resolutionIndex], heightList[resolutionIndex], fullScreen);

        Confirmar.SetActive(true);
        Opciones.SetActive(false);
        tiempoConfirmacion = timeCount;
        timer.text = "" + tiempoConfirmacion;
        StartCoroutine("ResCountDown");
    }

    IEnumerator ResCountDown()
    {
        for (int j = tiempoConfirmacion; j>=0; j--)
        {
            timer.text = "" + j;
            yield return new WaitForSeconds(1f);
            if( j == 0)
            {
                confirmarRes();
            }

        }
    }

    public void confirmarRes()
    {
        StopCoroutine("ResCountDown");
        Confirmar.SetActive(false);
        Opciones.SetActive(true);
        width = widthList[resolutionIndex];
        height = heightList[resolutionIndex];
        Screen.SetResolution(width, height, fullScreen);
    }

    public void cancelarRes()
    {
        StopCoroutine("ResCountDown");
        Confirmar.SetActive(false);
        Opciones.SetActive(true);
        Screen.SetResolution(width, height, fullScreen);
    }

    void Update()
    {
        
    }
}
