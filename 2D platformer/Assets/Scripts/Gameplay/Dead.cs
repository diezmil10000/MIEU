using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dead : MonoBehaviour
{

    [SerializeField] GameObject jumpscarePanel;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject player;
    [SerializeField] GameObject fadePanel;
    [SerializeField] AudioClip gameOverClip;
    [SerializeField] AudioClip jumpscareClip;

    [SerializeField] private GameObject jumpscareLarga;
    [SerializeField] private GameObject jumpscareGusan;
    [SerializeField] private GameObject jumpscareTrippy;


    //Videos 

    [SerializeField] private float jumpscareTime = 2.0f;


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.layer == 11)
        {
            onContactLarga();
        }
        else if (other.collider.gameObject.layer == 12)
        {
            onContactTrippy();
        }
        else if (other.collider.gameObject.layer == 13)
        {
            onContactGusan();
        }
    }

    private void onContactGusan()
    {
        player.SetActive(false);
        jumpscarePanel.SetActive(true);

        jumpscareGusan.SetActive(true);
        jumpscareTrippy.SetActive(false);
        jumpscareLarga.SetActive(false);



        //A los dos segundos llamamos a la función youLost();
        Invoke(nameof(youLost), jumpscareTime);

    }

    private void onContactLarga()
    {
        player.SetActive(false);
        jumpscarePanel.SetActive(true);

        jumpscareGusan.SetActive(false);
        jumpscareTrippy.SetActive(false);
        jumpscareLarga.SetActive(true);


        //A los dos segundos llamamos a la función youLost();
        Invoke(nameof(youLost), jumpscareTime);

    }

    private void onContactTrippy()
    {
        player.SetActive(false);
        jumpscarePanel.SetActive(true);

        jumpscareGusan.SetActive(false);
        jumpscareTrippy.SetActive(true);
        jumpscareLarga.SetActive(false);



        //A los dos segundos llamamos a la función youLost();
        Invoke(nameof(youLost), jumpscareTime);

    }

    public void youLost()
    {
        fadePanel.SetActive(false);

        jumpscareGusan.SetActive(false);
        jumpscareTrippy.SetActive(false);
        jumpscareLarga.SetActive(false);

        gameOver.SetActive(true);
        Time.timeScale = 0f;
        SoundManager.Instance.PlaySound(gameOverClip);
    }

}
