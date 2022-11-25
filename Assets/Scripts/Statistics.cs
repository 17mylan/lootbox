using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statistics : MonoBehaviour
{
    private int gold;
    public Text goldScoreText;

    private int allGold;
    public Text allGoldScoreText;

    public void Start()
    {
        goldScoreText.text = PlayerPrefs.GetInt("gold", gold).ToString();
        gold = PlayerPrefs.GetInt("gold", gold);

        allGoldScoreText.text = PlayerPrefs.GetInt("allGold", allGold).ToString();
        allGold = PlayerPrefs.GetInt("allGold", allGold);
    }
    public void ButtonClick(string _String)
    {
        if(_String == "GoldButton")
        {
            gold++;
            PlayerPrefs.SetInt("gold", gold);
            goldScoreText.text = PlayerPrefs.GetInt("gold", gold).ToString();

            allGold++;
            PlayerPrefs.SetInt("allGold", allGold);
            allGoldScoreText.text = PlayerPrefs.GetInt("allGold", allGold).ToString();
        }
    }
}
