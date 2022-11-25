using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
