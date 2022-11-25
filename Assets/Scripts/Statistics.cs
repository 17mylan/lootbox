using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Statistics : MonoBehaviour
{
    public int gold;
    public Text goldScoreText;

    public int allGold;
    public Text allGoldScoreText;

    public void Start()
    {
        goldScoreText.text = PlayerPrefs.GetInt("gold", gold).ToString();
        gold = PlayerPrefs.GetInt("gold", gold);
        CheckStats();
    }
    public void ButtonClick(string _String)
    {
        if(_String == "GoldButton")
        {
            gold++;
            PlayerPrefs.SetInt("gold", gold);
            goldScoreText.text = PlayerPrefs.GetInt("gold", gold).ToString();
            CheckStats();
        }
        if(_String == "BuyChestCommon")
        {
            if(PlayerPrefs.GetInt("gold", gold) >= 10)
            {
                gold = (PlayerPrefs.GetInt("gold", gold)) - 10;
                PlayerPrefs.SetInt("gold", gold);
                goldScoreText.text = PlayerPrefs.GetInt("gold", gold).ToString();
                // Mettre scene du coffre
                // ajouter + 1 aux stats des coffres
            }
        }
        if(_String == "BuyChestRare")
        {
            if(PlayerPrefs.GetInt("gold", gold) >= 50)
            {
                gold = (PlayerPrefs.GetInt("gold", gold)) - 50;
                PlayerPrefs.SetInt("gold", gold);
                goldScoreText.text = PlayerPrefs.GetInt("gold", gold).ToString();
                // Mettre scene du coffre
                // ajouter + 1 aux stats des coffres
            }
        }
        if(_String == "BuyChestEpic")
        {
            if(PlayerPrefs.GetInt("gold", gold) >= 100)
            {
                gold = (PlayerPrefs.GetInt("gold", gold)) - 100;
                PlayerPrefs.SetInt("gold", gold);
                goldScoreText.text = PlayerPrefs.GetInt("gold", gold).ToString();
                // Mettre scene du coffre
                // ajouter + 1 aux stats des coffres
            }
        }
    }
    public void CheckStats()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Main")
        {
            allGoldScoreText.text = PlayerPrefs.GetInt("allGold", allGold).ToString();
            allGold = PlayerPrefs.GetInt("allGold", allGold);

            allGold++;
            PlayerPrefs.SetInt("allGold", allGold);
            allGoldScoreText.text = PlayerPrefs.GetInt("allGold", allGold).ToString();
        }
    }
}
