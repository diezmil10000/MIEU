using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class InteractionSystem : MonoBehaviour
{

    public Transform detectionPoint;
    private const float detectionRadius = 0.2f;
    public LayerMask detectionLayer;
    public LayerMask monsterLayer;

    //Sonido de taquilla
    [SerializeField] private AudioClip _clip;

    //Cogemos al jugador
    [SerializeField] private GameObject player;

    //Pantalla de esconderse en la taquilla (es un panel)
    [SerializeField] private GameObject lockerScreen;

    void Update()
    {
        if (DetectObject())
        {
            if (InteractInput())
            {
                locker();
            }
        }
    }




    bool InteractInput() 
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    bool DetectObject()
    {
        return Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);
    
    }

    private void locker() 
    {

        if (player.activeSelf == true)
        {
            if (InteractInput())
            {
                lockerScreen.SetActive(true);
                player.SetActive(false);
                SoundManager.Instance.PlaySound(_clip);
            }

        } else if (player.activeSelf == false)
        {
            lockerScreen.SetActive(false);
            player.SetActive(true);
            SoundManager.Instance.PlaySound(_clip);
        }

    }

    

    private void ExitLocker()
    {
        if (player.activeSelf == false)
        {
            if (InteractInput())
            {
                player.SetActive(true);

            }
        }
       
    }

    /*
    private void MonsterCollision(Collision alfa)
    {
       

    }

    private void reiniciarMuerte()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    */
}
