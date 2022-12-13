using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // ___________________________________________
    // |                                          |
    // |                VARIABLES                 |
    // |__________________________________________|
    [Header("Game Object")]
    public GameObject Options;
    public GameObject Profile;
    public GameObject Shop;
    public GameObject ShopUltime;
    public GameObject CommonChestPopUp;
    public GameObject RareChestPopUp;
    public GameObject EpicChestPopUp;
    public GameObject GoldButton;
    [Header("Text")]
    public Text playername;
    public InputField display;
    [Header("Other")]
    Statistics statistics;
    Cards cards;
    public AudioSource buttonClickSound;
    public AudioClip sound_buttonClickSound;
    // ___________________________________________
    // |                                          |
    // |              MONOBEHAVIOR                |
    // |__________________________________________|
    public void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene(); // string.IsNullOrWhiteSpace(player1Name))
        string sceneName = currentScene.name;
        if (sceneName == "Main")
        {
            playername.text = PlayerPrefs.GetString("playername");
        }
    }
    // ___________________________________________
    // |                                          |
    // |            PUBLIC FONCTION               |
    // |__________________________________________|
    public void Create()
    {
        playername.text = display.text;
        PlayerPrefs.SetString("playername", playername.text);
    }
    public void ButtonClick(string _String)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (_String == "Options")
        {
            if (sceneName == "Main")
            {
                Profile.SetActive(false);
                GoldButton.SetActive(false);
            }
            if(sceneName == "Shop")
            {
                Shop.SetActive(false);
                ShopUltime.SetActive(false);
                CommonChestPopUp.SetActive(false);
                RareChestPopUp.SetActive(false);
                EpicChestPopUp.SetActive(false);
            }
            if(sceneName == "Cards")
            {
                cards = FindObjectOfType<Cards>();
                cards.CloseAllCards("All");
            }
            Options.SetActive(true);
        }
        if (_String == "CloseOptions")
        {
            if (sceneName == "Main")
            {
                GoldButton.SetActive(true);
            }
            if(sceneName == "Shop")
            {
                Shop.SetActive(true);
                if (PlayerPrefs.GetInt("Cards_10") == 0)
                {
                    for (int i = 1; i < 10; i++)
                    {
                        if (PlayerPrefs.GetInt("Cards_" + i) == 1)
                        {
                            ShopUltime.SetActive(true);
                            Shop.SetActive(false);
                        }
                        else
                        {
                            ShopUltime.SetActive(false);
                            Shop.SetActive(true);
                        }
                    }
                }
            }
            Options.SetActive(false);
        }
        if (_String == "Profile")
        {
            if (sceneName == "Main")
            {
                Profile.SetActive(true);
                GoldButton.SetActive(false);
            }
            Options.SetActive(false);
        }
        if (_String == "CloseProfile")
        {
            if (sceneName == "Main")
            {
                GoldButton.SetActive(true);
            }
            Profile.SetActive(false);
        }
        if(_String == "CancelShop")
        {
            Shop.SetActive(true);
            CommonChestPopUp.SetActive(false);
            RareChestPopUp.SetActive(false);
            EpicChestPopUp.SetActive(false);
        }
        if(_String == "CommonChestPopUp")
        {
            Shop.SetActive(false);
            CommonChestPopUp.SetActive(true);
        }
        if(_String == "RareChestPopUp")
        {
            Shop.SetActive(false);
            RareChestPopUp.SetActive(true);
        }
        if(_String == "EpicChestPopUp")
        {
            Shop.SetActive(false);
            EpicChestPopUp.SetActive(true);
        }
        buttonClickSound.PlayOneShot(sound_buttonClickSound);
    }
    public void ChangeScene(string _sceneName)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName != _sceneName)
        {
            SceneManager.LoadScene(_sceneName);
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
}