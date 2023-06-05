using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dead : MonoBehaviour
{

    [SerializeField] GameObject jumpscarePanel;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject player;
    [SerializeField] AudioClip gameOverClip;
    [SerializeField] AudioClip jumpscareClip;

    [SerializeField] private Image trippy;
    [SerializeField] private Image larga;
    [SerializeField] private Image gusan;

    [SerializeField] private float jumpscareTime = 2.0f;


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.layer == 11)
        {
            Debug.Log("larga");
            onContactLarga();
        }
        else if (other.collider.gameObject.layer == 12)
        {
            Debug.Log("trippy");
            onContactTrippy();
        }
        else if (other.collider.gameObject.layer == 13)
        {
            Debug.Log("gusan");
            onContactGusan();
        }
    }

    private void onContactGusan()
    {
        player.SetActive(false);
        SoundManager.Instance.PlaySound(jumpscareClip);
        jumpscarePanel.SetActive(true);
        trippy.enabled = false;
        larga.enabled = false;
        gusan.enabled = true;



        //A los dos segundos llamamos a la función youLost();
        Invoke(nameof(youLost), jumpscareTime);

    }

    private void onContactLarga()
    {
        player.SetActive(false);
        SoundManager.Instance.PlaySound(jumpscareClip);
        jumpscarePanel.SetActive(true);
        trippy.enabled = false;
        larga.enabled = true;
        gusan.enabled = false;


        //A los dos segundos llamamos a la función youLost();
        Invoke(nameof(youLost), jumpscareTime);

    }

    private void onContactTrippy()
    {
        player.SetActive(false);
        SoundManager.Instance.PlaySound(jumpscareClip);
        jumpscarePanel.SetActive(true);
        trippy.enabled = true;
        larga.enabled = false;
        gusan.enabled = false;


        //A los dos segundos llamamos a la función youLost();
        Invoke(nameof(youLost), jumpscareTime);

    }

    public void youLost()
    {
        jumpscarePanel.SetActive(false);
        gameOver.SetActive(true);
        Time.timeScale = 0f;
        SoundManager.Instance.PlaySound(gameOverClip);
    }

}
