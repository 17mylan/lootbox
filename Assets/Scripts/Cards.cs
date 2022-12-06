using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cards : MonoBehaviour
{
    public GameObject Stive;
    public GameObject PrLeton;
    public GameObject EthanSummer;
    public GameObject Sonic;
    public GameObject Claude;
    public GameObject TomKoon;
    public GameObject Pika;
    public GameObject Zailda;
    public GameObject Mario;
    public GameObject Remi;

    public GameObject BackgroundCards;
    public GameObject Canvas;

    public GameObject Stive_OpenCard;
    public GameObject PrLeton_OpenCard;
    public GameObject EthanSummer_OpenCard;
    public GameObject Sonic_OpenCard;
    public GameObject Claude_OpenCard;
    public GameObject TomKoon_OpenCard;
    public GameObject Pika_OpenCard;
    public GameObject Zailda_OpenCard;
    public GameObject Mario_OpenCard;
    public GameObject Remi_OpenCard;

    public int NumberOfCards = 5;
    public Text NumberOfCardsText;
    public void buttonClicked(string _String)
    {
        BackgroundCards.SetActive(true);
        Canvas.SetActive(true);
        if (_String == "CloseOpenCards")
        {
            BackgroundCards.SetActive(false);
            Canvas.SetActive(false);
            Stive_OpenCard.SetActive(false);
            PrLeton_OpenCard.SetActive(false);
            EthanSummer_OpenCard.SetActive(false);
            Sonic_OpenCard.SetActive(false);
            Claude_OpenCard.SetActive(false);
            TomKoon_OpenCard.SetActive(false);
            Pika_OpenCard.SetActive(false);
            Zailda_OpenCard.SetActive(false);
            Mario_OpenCard.SetActive(false);
            Remi_OpenCard.SetActive(false);
        }
        if(_String == "Stive")
        {
            Stive_OpenCard.SetActive(true);
        }
        if (_String == "PrLeton")
        {
            PrLeton_OpenCard.SetActive(true);
        }
        if (_String == "EthanSummer")
        {
            EthanSummer_OpenCard.SetActive(true);
        }
        if (_String == "Sonic")
        {
            Sonic_OpenCard.SetActive(true);
        }
        if (_String == "Claude")
        {
            Claude_OpenCard.SetActive(true);
        }
        if (_String == "TomKoon")
        {
            TomKoon_OpenCard.SetActive(true);
        }
        if (_String == "Pika")
        {
            Pika_OpenCard.SetActive(true);
        }
        if (_String == "Zailda")
        {
            Zailda_OpenCard.SetActive(true);
        }
        if (_String == "Mario")
        {
            Mario_OpenCard.SetActive(true);
        }
        if (_String == "Remi")
        {
            Remi_OpenCard.SetActive(true);
        }
    }
    public void Start()
    {
        if(PlayerPrefs.GetInt("Stive") == 0)
        {
            Stive.GetComponent<SpriteRenderer>().color = Color.gray;
            NumberOfCards--;
        }
        if (PlayerPrefs.GetInt("PrLeton") == 0)
        {
            PrLeton.GetComponent<SpriteRenderer>().color = Color.gray;
            NumberOfCards--;
        }
        if (PlayerPrefs.GetInt("EthanSummer") == 0)
        {
            EthanSummer.GetComponent<SpriteRenderer>().color = Color.gray;
            NumberOfCards--;
        }
        if (PlayerPrefs.GetInt("Sonic") == 0)
        {
            Sonic.GetComponent<SpriteRenderer>().color = Color.gray;
            NumberOfCards--;
        }
        if (PlayerPrefs.GetInt("Claude") == 0)
        {
            Claude.GetComponent<SpriteRenderer>().color = Color.gray;
            NumberOfCards--;
        }
        if (PlayerPrefs.GetInt("TomKoon") == 0)
        {
            TomKoon.GetComponent<SpriteRenderer>().color = Color.gray;
            NumberOfCards--;
        }
        if (PlayerPrefs.GetInt("Pika") == 0)
        {
            Pika.GetComponent<SpriteRenderer>().color = Color.gray;
            NumberOfCards--;
        }
        if (PlayerPrefs.GetInt("Zailda") == 0)
        {
            Zailda.GetComponent<SpriteRenderer>().color = Color.gray;
            NumberOfCards--;
        }
        if (PlayerPrefs.GetInt("Mario") == 0)
        {
            Mario.GetComponent<SpriteRenderer>().color = Color.gray;
            NumberOfCards--;
        }
        if (PlayerPrefs.GetInt("Remi") == 0)
        {
            Remi.GetComponent<SpriteRenderer>().color = Color.gray;
            NumberOfCards--;
        }
        NumberOfCardsText.text = NumberOfCards.ToString();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerPrefs.SetInt("Stive", 1);
            PlayerPrefs.SetInt("PrLeton", 1);
            PlayerPrefs.SetInt("EthanSummer", 1);
            PlayerPrefs.SetInt("Sonic", 1);
            PlayerPrefs.SetInt("Claude", 1);
            PlayerPrefs.SetInt("TomKoon", 1);
            PlayerPrefs.SetInt("Pika", 1);
            PlayerPrefs.SetInt("Zailda", 1);
            PlayerPrefs.SetInt("Mario", 1);
            PlayerPrefs.SetInt("Remi", 1);
            SceneManager.LoadScene("Cards");
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            PlayerPrefs.SetInt("Stive", 0);
            PlayerPrefs.SetInt("PrLeton", 0);
            PlayerPrefs.SetInt("EthanSummer", 0);
            PlayerPrefs.SetInt("Sonic", 0);
            PlayerPrefs.SetInt("Claude", 0);
            PlayerPrefs.SetInt("TomKoon", 0);
            PlayerPrefs.SetInt("Pika", 0);
            PlayerPrefs.SetInt("Zailda", 0);
            PlayerPrefs.SetInt("Mario", 0);
            PlayerPrefs.SetInt("Remi", 0);
            SceneManager.LoadScene("Cards");
        }
    }
}
