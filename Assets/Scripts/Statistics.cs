using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Statistics : MonoBehaviour
{
    // ___________________________________________
    // |                                          |
    // |                VARIABLES                 |
    // |__________________________________________|
    public int gold;
    public Text goldScoreText;
    public int allGold;
    public Text allGoldScoreText;
    public int commonChestCounter;
    public Text commonChestCounterText;
    public int rareChestCounter;
    public Text rareChestCounterText;
    public int epicChestCounter;
    public Text epicChestCounterText;
    public ParticleSystem particleSys;
    public GameObject button;

    // ___________________________________________
    // |                                          |
    // |              MONOBEHAVIOR                |
    // |__________________________________________|
    public void Start()
    {
        goldScoreText.text = PlayerPrefs.GetInt("gold", gold).ToString();
        gold = PlayerPrefs.GetInt("gold", gold);
        CheckStats();
    }

    // ___________________________________________
    // |                                          |
    // |            PUBLIC FONCTION               |
    // |__________________________________________|
    IEnumerator ButtonScale()
    {
        button.transform.localScale = new Vector3(0.8f,0.8f,0.8f);
        yield return new WaitForSeconds(0.1f);
        button.transform.localScale = new Vector3(1,1,1);
    }
    public void ButtonClick(string _String)
    {
        if(_String == "MaxGold")
        {
            gold = 9999;
            PlayerPrefs.SetInt("gold", 9999);
            goldScoreText.text = PlayerPrefs.GetInt("gold", gold).ToString();
        }
        if(_String == "GoldButton")
        {
            particleSys.Play();
            StartCoroutine("ButtonScale");
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
                commonChestCounter = PlayerPrefs.GetInt("CommonChestCounter", commonChestCounter) + 1;
                PlayerPrefs.SetInt("CommonChestCounter", commonChestCounter);
            }
        }
        if(_String == "BuyChestRare")
        {
            if(PlayerPrefs.GetInt("gold", gold) >= 50)
            {
                gold = (PlayerPrefs.GetInt("gold", gold)) - 50;
                PlayerPrefs.SetInt("gold", gold);
                goldScoreText.text = PlayerPrefs.GetInt("gold", gold).ToString();
                rareChestCounter = PlayerPrefs.GetInt("RareChestCounter", rareChestCounter) + 1;
                PlayerPrefs.SetInt("RareChestCounter", rareChestCounter);
            }
        }
        if(_String == "BuyChestEpic")
        {
            if(PlayerPrefs.GetInt("gold", gold) >= 100)
            {
                gold = (PlayerPrefs.GetInt("gold", gold)) - 100;
                PlayerPrefs.SetInt("gold", gold);
                goldScoreText.text = PlayerPrefs.GetInt("gold", gold).ToString();
                epicChestCounter = PlayerPrefs.GetInt("EpicChestCounter", epicChestCounter) + 1;
                PlayerPrefs.SetInt("EpicChestCounter", epicChestCounter);
            }
        }
    }
    public void CheckStats()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Main")
        {
            particleSys = GameObject.Find("Particle System").GetComponent<ParticleSystem>();
            allGoldScoreText.text = PlayerPrefs.GetInt("allGold", allGold).ToString();
            allGold = PlayerPrefs.GetInt("allGold", allGold);
            allGold++;
            PlayerPrefs.SetInt("allGold", allGold);
            allGoldScoreText.text = PlayerPrefs.GetInt("allGold", allGold).ToString();
            commonChestCounter = PlayerPrefs.GetInt("CommonChestCounter", commonChestCounter);
            commonChestCounterText.text = PlayerPrefs.GetInt("CommonChestCounter", commonChestCounter).ToString();
            rareChestCounter = PlayerPrefs.GetInt("RareChestCounter", rareChestCounter);
            rareChestCounterText.text = PlayerPrefs.GetInt("RareChestCounter", rareChestCounter).ToString();
            epicChestCounter = PlayerPrefs.GetInt("EpicChestCounter", epicChestCounter);
            epicChestCounterText.text = PlayerPrefs.GetInt("EpicChestCounter", epicChestCounter).ToString();
        }
    }
}