using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{

    [SerializeField] GameObject jumpscarePanel;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject player;
    [SerializeField] AudioClip gameOverClip;
    [SerializeField] AudioClip jumpscareClip;

    [SerializeField] private float jumpscareTime = 2.0f;


    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.gameObject.tag == "Enemy")
        {
            Debug.Log("Tocaste");
            onContact();
        }
    }

    private void onContact()
    {
        player.SetActive(false);
        SoundManager.Instance.PlaySound(jumpscareClip);
        jumpscarePanel.SetActive(true);

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
