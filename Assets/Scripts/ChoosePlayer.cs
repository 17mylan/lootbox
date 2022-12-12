using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePlayer : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    public void Awake()
    {
        if (PlayerPrefs.GetInt("Player") == 1)
        {
            player1.SetActive(true);
            player2.SetActive(false);

        }
        else if (PlayerPrefs.GetInt("Player") == 2)
        {
            player1.SetActive(false);
            player2.SetActive(true);
        }
    }
    public void ButtonClicked(string _String)
    {
        if (_String == "Player1")
        {
            player1.SetActive(true);
            player2.SetActive(false);
            PlayerPrefs.SetInt("Player", 1);
        }
        else if (_String == "Player2")
        {
            player1.SetActive(false);
            player2.SetActive(true);
            PlayerPrefs.SetInt("Player", 2);
        }
    }
}