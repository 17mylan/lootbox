using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cards : MonoBehaviour
{
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
    public int NumberOfCards = 10;
    public Text NumberOfCardsText;
    public GameObject locked;
    public GameObject topSecret;
    public Sprite card_10_blur;
    public void Start()
    {
        for (int i = 1; i < 11; i++)
        {
            if (PlayerPrefs.GetInt("Cards_" + i) == 0)
            {
                NumberOfCards--;
                GameObject.Find("Cards_" + i).GetComponent<SpriteRenderer>().color = Color.grey;
                this.transform.position = GameObject.Find("Cards_" + i).GetComponent<Transform>().position;
                Instantiate(locked, this.transform.position, Quaternion.identity);
                if (PlayerPrefs.GetInt("Cards_10") == 0)
                {
                    GameObject.Find("Cards_10").GetComponent<SpriteRenderer>().sprite = card_10_blur;
                    this.transform.position = GameObject.Find("Cards_10").GetComponent<Transform>().position;
                    Instantiate(topSecret, this.transform.position + new Vector3(0, 0.7f, 0), Quaternion.identity);
                }
            }
        }
        NumberOfCardsText.text = NumberOfCards.ToString();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            for (int i = 1; i < 11; i++)
            {
                PlayerPrefs.SetInt("Cards_" + i, 1);
            }
            SceneManager.LoadScene("Cards");
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            for (int i = 1; i < 11; i++)
            {
                PlayerPrefs.SetInt("Cards_" + i, 0);
            }
            SceneManager.LoadScene("Cards");
        }
    }
    public void buttonClicked(string _String)
    {
        if (_String == "Remi")
        {
            if (PlayerPrefs.GetInt("Cards_10") == 1)
            {
                Remi_OpenCard.SetActive(true);
                BackgroundCards.SetActive(true);
                Canvas.SetActive(true);
            }
        }
        else
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
            if (_String == "Stive")
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
        }
    }
}