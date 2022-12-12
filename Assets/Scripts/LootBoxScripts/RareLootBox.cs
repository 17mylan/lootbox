using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RareLootBox : MonoBehaviour
{

    public GameObject lootBox;

    public GameObject Open;
    public GameObject Exit;

    public GameObject Particles;

    public GameObject Commun1;
    public GameObject Commun2;
    public GameObject Commun3;
    public GameObject Rare1;
    public GameObject Rare2;
    public GameObject Rare3;
    public GameObject Epic1;
    public GameObject Epic2;
    public GameObject Epic3;
    public GameObject Doublons;
    public Text DoublonsText;

    public Statistics statistics;
    public int gold;


    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void ParticlesSystem()
    {
        Particles.SetActive(true);
    }

    public void DestroyBox()
    {
        lootBox.SetActive(false);
    }
    public void buttonClick(string _String)
    {
        if (_String == "boxOpen")
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Open", true);

            Invoke("ParticlesSystem", .6f);
            Invoke("LootSpawnn", .6f);
            Invoke("DestroyBox", 2.0f);

            Open.SetActive(false);
            Exit.SetActive(true);
        }

        if (_String == "LeaveScene")
        {
            SceneManager.LoadScene("Main");
        }
        //Invoke("LootSpawnn", 2.0f);
    }
    public void ReturnGold(string _String)
    {
        gold = PlayerPrefs.GetInt("gold", gold);
        Doublons.SetActive(true);
        if (_String == "1")
        {
            gold = gold + 25;
            DoublonsText.text = "You already have this card !\n +25 Golds";
        }
        if (_String == "2")
        {
            gold = gold + 125;
            DoublonsText.text = "You already have this card !\n +125 Golds";
        }
        if (_String == "3")
        {
            gold = gold + 250;
            DoublonsText.text = "You already have this card !\n +250 Golds";
        }
        PlayerPrefs.SetInt("gold", gold);
    }
    public void LootSpawnn()
    {
        float randomNum = Random.Range(0, 100);
        float randomNum2 = Random.Range(1, 4);

        if (randomNum <= 60)
        {
            if (randomNum2 == 1)
            {
                Commun1.SetActive(true);
                if (PlayerPrefs.GetInt("Cards_1") == 1)
                {
                    ReturnGold("1");
                }
                else
                {
                    PlayerPrefs.SetInt("Cards_1", 1);
                }
            }
            if (randomNum2 == 2)
            {
                Commun2.SetActive(true);
                if (PlayerPrefs.GetInt("Cards_2") == 1)
                {
                    ReturnGold("1");
                }
                else
                {
                    PlayerPrefs.SetInt("Cards_2", 1);
                }
            }
            if (randomNum2 == 3)
            {
                Commun3.SetActive(true);
                if (PlayerPrefs.GetInt("Cards_3") == 1)
                {
                    ReturnGold("1");
                }
                else
                {
                    PlayerPrefs.SetInt("Cards_3", 1);
                }
            }

            //card1.SetActive(true);
        }

        if (randomNum > 60 && randomNum <= 98)
        {
            if (randomNum2 == 1)
            {
                Rare1.SetActive(true);
                if (PlayerPrefs.GetInt("Cards_4") == 1)
                {
                    ReturnGold("2");
                }
                else
                {
                    PlayerPrefs.SetInt("Cards_4", 1);
                }
            }
            if (randomNum2 == 2)
            {
                Rare2.SetActive(true);
                if (PlayerPrefs.GetInt("Cards_5") == 1)
                {
                    ReturnGold("2");
                }
                else
                {
                    PlayerPrefs.SetInt("Cards_5", 1);
                }
            }
            if (randomNum2 == 3)
            {
                Rare3.SetActive(true);
                if (PlayerPrefs.GetInt("Cards_6") == 1)
                {
                    ReturnGold("2");
                }
                else
                {
                    PlayerPrefs.SetInt("Cards_6", 1);
                }
            }

            //card2.SetActive(true);
        }

        if (randomNum > 98 && randomNum <= 100)
        {
            if (randomNum2 == 1)
            {
                Epic1.SetActive(true);
                if (PlayerPrefs.GetInt("Cards_7") == 1)
                {
                    ReturnGold("3");
                }
                else
                {
                    PlayerPrefs.SetInt("Cards_7", 1);
                }
            }
            if (randomNum2 == 2)
            {
                Epic2.SetActive(true);
                if (PlayerPrefs.GetInt("Cards_8") == 1)
                {
                    ReturnGold("3");
                }
                else
                {
                    PlayerPrefs.SetInt("Cards_8", 1);
                }
            }
            if (randomNum2 == 3)
            {
                Epic3.SetActive(true);
                if (PlayerPrefs.GetInt("Cards_9") == 1)
                {
                    ReturnGold("3");
                }
                else
                {
                    PlayerPrefs.SetInt("Cards_9", 1);
                }
            }

            //card3.SetActive(true);
        }

        Exit.SetActive(true);
    }
}
