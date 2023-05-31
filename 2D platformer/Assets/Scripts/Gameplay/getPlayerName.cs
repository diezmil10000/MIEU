using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class getPlayerName : MonoBehaviour
{

    [SerializeField] private string playerName;
    [SerializeField] private string saveName;

    [SerializeField] private GameObject getNamePanel;

    [SerializeField] Text loadedName;
    [SerializeField] Text inputText;


    private void Awake()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        playerName = PlayerPrefs.GetString("name", "none");
        loadedName.text = playerName;

        if (Input.GetKey(KeyCode.Return))
        {
            setName();
            Time.timeScale = 1;
            Destroy(getNamePanel.gameObject);

        }
    }


    public void setName()
    {
        saveName = inputText.text;
        PlayerPrefs.SetString("name", saveName);
    }

}
