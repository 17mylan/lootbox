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
    [Header ("Text & Integer")]
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
    public int numberOfCardsUnlocked;
    public Text numberOfCardsUnlockedText;
    public float randomValue;
    float timePassed = 0f;
    [Header("Particle System")]
    public ParticleSystem particleSys;
    public ParticleSystem particleSysNewChest;
    public ParticleSystem particleSysNewChestRare;
    [Header("Game Object & Sprites")]
    public GameObject button;
    public Sprite nativeChest;
    public Sprite newChest;
    public Sprite newChestRare;
    public GameObject legendaryBG;
    public GameObject legendaryParticle;
    public GameObject goldBG;
    public AudioSource goldSound;
    public AudioClip goldSoundClip;
    public AudioSource LegendarySound;
    public AudioClip legendarySoundClip;
    public GameObject Shop;
    public GameObject ShopPage2;
    public GameObject ShopUltime;
    public GameObject autoClickerButtonTrue;
    public GameObject autoClickerButtonFalse;
    public GameObject autoClickerText;
    Cards cards;
    public bool AutoClickerStatus = true;
    // ___________________________________________
    // |                                          |
    // |              MONOBEHAVIOR                |
    // |__________________________________________|
    public void Start()
    {
        goldScoreText.text = PlayerPrefs.GetInt("gold", gold).ToString();
        gold = PlayerPrefs.GetInt("gold", gold);
        CheckStats();
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Shop")
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
        if(sceneName == "Main")
        {
            if(PlayerPrefs.GetInt("AutoClicker") == 1)
            {
                autoClickerText.SetActive(true);
                if(AutoClickerStatus == true)
                {
                    autoClickerButtonTrue.SetActive(true);
                    autoClickerButtonFalse.SetActive(false);
                }
                else if(AutoClickerStatus == false)
                {
                    autoClickerButtonTrue.SetActive(false);
                    autoClickerButtonFalse.SetActive(true);
                }
            }
            else if (PlayerPrefs.GetInt("AutoClicker") == 0)
            {
                autoClickerText.SetActive(false);
                autoClickerButtonTrue.SetActive(false);
                autoClickerButtonFalse.SetActive(false);
            }
        }
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

    // Cheat code Dev
    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Main")
        {
            if(PlayerPrefs.GetInt("AutoClicker") == 1)
            {
                if(AutoClickerStatus == true)
                {
                    timePassed += Time.deltaTime;
                    if(timePassed > 1.6f)
                    {
                        timePassed = 0f;
                        button.GetComponent<Button>().onClick.Invoke();
                    }
                }
            }
            if(Input.GetKeyDown(KeyCode.I))
            {
                button.GetComponent<Image>().sprite = nativeChest;
                legendaryBG.SetActive(false);
                legendaryParticle.SetActive(false);
                goldBG.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                button.GetComponent<Image>().sprite = newChest;
                legendaryBG.SetActive(false);
                legendaryParticle.SetActive(false);
                goldBG.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                button.GetComponent<Image>().sprite = newChestRare;
                legendaryBG.SetActive(true);
                legendaryParticle.SetActive(true);
                goldBG.SetActive(false);
            }
            if(Input.GetKeyDown(KeyCode.N))
            {
                PlayerPrefs.SetInt("AutoClicker", 0);
                AutoClickerStatus = false;
            }
        }
    }
    public void ButtonClick(string _String)
    {
        if (_String == "ShopPage1")
        {
            Shop.SetActive(true);
            ShopPage2.SetActive(false);
        }
        if (_String == "ShopPage2")
        {
            Shop.SetActive(false);
            ShopPage2.SetActive(true);
        }
        if(_String == "BuyAutoClicker")
        {
            if (PlayerPrefs.GetInt("AutoClicker") == 0)
            {
                if (PlayerPrefs.GetInt("gold", gold) >= 10000)
                {
                    gold = (PlayerPrefs.GetInt("gold", gold)) - 10000;
                    PlayerPrefs.SetInt("gold", gold);
                    goldScoreText.text = PlayerPrefs.GetInt("gold", gold).ToString();
                    PlayerPrefs.SetInt("AutoClicker", 1);
                }
            }
        }
        if(_String == "MaxGold")
        {
            gold = 9999;
            PlayerPrefs.SetInt("gold", 9999);
            goldScoreText.text = PlayerPrefs.GetInt("gold", gold).ToString();
        }
        if(_String == "GoldButton")
        {
            if (button.GetComponent<Image>().sprite == newChest)
            {
                button.GetComponent<Image>().sprite = nativeChest;
                goldSound.PlayOneShot(goldSoundClip);
                gold = gold + 10;
                allGold = PlayerPrefs.GetInt("allGold", allGold);
                allGold = allGold + 10;
                PlayerPrefs.SetInt("allGold", allGold);
                particleSysNewChest.Play();
                goldBG.SetActive(false);
            }
            else if (button.GetComponent<Image>().sprite == newChestRare)
            {
                button.GetComponent<Image>().sprite = nativeChest;
                LegendarySound.PlayOneShot(legendarySoundClip);
                gold = gold + 75;
                allGold = PlayerPrefs.GetInt("allGold", allGold);
                allGold = allGold + 75;
                PlayerPrefs.SetInt("allGold", allGold);
                particleSysNewChestRare.Play();
                legendaryBG.SetActive(false);
                legendaryParticle.SetActive(false);
            }
            else
            {
                gold++;
                allGold = PlayerPrefs.GetInt("allGold", allGold);
                allGold++;
                PlayerPrefs.SetInt("allGold", allGold);
                particleSys.Play();
            }
            StartCoroutine("ButtonScale");
            PlayerPrefs.SetInt("gold", gold);
            goldScoreText.text = PlayerPrefs.GetInt("gold", gold).ToString();
            CheckStats();
        }
        if(_String == "BuyChestCommon")
        {
            if(PlayerPrefs.GetInt("gold", gold) >= 50)
            {
                gold = (PlayerPrefs.GetInt("gold", gold)) - 50;
                PlayerPrefs.SetInt("gold", gold);
                goldScoreText.text = PlayerPrefs.GetInt("gold", gold).ToString();
                commonChestCounter = PlayerPrefs.GetInt("CommonChestCounter", commonChestCounter) + 1;
                PlayerPrefs.SetInt("CommonChestCounter", commonChestCounter);
                SceneManager.LoadScene(3);
            }
        }
        if(_String == "BuyChestRare")
        {
            if(PlayerPrefs.GetInt("gold", gold) >= 250)
            {
                gold = (PlayerPrefs.GetInt("gold", gold)) - 250;
                PlayerPrefs.SetInt("gold", gold);
                goldScoreText.text = PlayerPrefs.GetInt("gold", gold).ToString();
                rareChestCounter = PlayerPrefs.GetInt("RareChestCounter", rareChestCounter) + 1;
                PlayerPrefs.SetInt("RareChestCounter", rareChestCounter);
                SceneManager.LoadScene(5);
            }
        }
        if(_String == "BuyChestEpic")
        {
            if(PlayerPrefs.GetInt("gold", gold) >= 500)
            {
                gold = (PlayerPrefs.GetInt("gold", gold)) - 500;
                PlayerPrefs.SetInt("gold", gold);
                goldScoreText.text = PlayerPrefs.GetInt("gold", gold).ToString();
                epicChestCounter = PlayerPrefs.GetInt("EpicChestCounter", epicChestCounter) + 1;
                PlayerPrefs.SetInt("EpicChestCounter", epicChestCounter);
                SceneManager.LoadScene(4);
            }
        }
        if(_String == "BuyUltimeChest")
        {
            if(PlayerPrefs.GetInt("gold", gold) >= 10000)
            {
                gold = (PlayerPrefs.GetInt("gold", gold)) - 10000;
                PlayerPrefs.SetInt("gold", gold);
                goldScoreText.text = PlayerPrefs.GetInt("gold", gold).ToString();
                PlayerPrefs.SetInt("Cards_10", 1);
                SceneManager.LoadScene(6);
            }
        }
    }
    public void CheckStats()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Main")
        {
            allGold = PlayerPrefs.GetInt("allGold", allGold);
            allGoldScoreText.text = PlayerPrefs.GetInt("allGold", allGold).ToString();
            commonChestCounter = PlayerPrefs.GetInt("CommonChestCounter", commonChestCounter);
            commonChestCounterText.text = PlayerPrefs.GetInt("CommonChestCounter", commonChestCounter).ToString();
            rareChestCounter = PlayerPrefs.GetInt("RareChestCounter", rareChestCounter);
            rareChestCounterText.text = PlayerPrefs.GetInt("RareChestCounter", rareChestCounter).ToString();
            epicChestCounter = PlayerPrefs.GetInt("EpicChestCounter", epicChestCounter);
            epicChestCounterText.text = PlayerPrefs.GetInt("EpicChestCounter", epicChestCounter).ToString();
            for (int i = 1; i < 11; i++)
            {
                if(PlayerPrefs.GetInt("Cards_" + i) == 1)
                {
                    numberOfCardsUnlocked++;
                }
            }
            numberOfCardsUnlockedText.text = numberOfCardsUnlocked.ToString();
            randomValue = Random.Range(0f, 100f);
            if (randomValue < 4f)
            {
                button.GetComponent<Image>().sprite = newChest;
                goldBG.SetActive(true);
            }
            else if (randomValue > 99.5f)
            {
                button.GetComponent<Image>().sprite = newChestRare;
                legendaryBG.SetActive(true);
                legendaryParticle.SetActive(true);
            }
        }
    }
    public void AutoClickerOn()
    {
        AutoClickerStatus = true;
        autoClickerButtonTrue.SetActive(true);
        autoClickerButtonFalse.SetActive(false);
    }    
    public void AutoClickerOff()
    {
        AutoClickerStatus = false;
        autoClickerButtonTrue.SetActive(false);
        autoClickerButtonFalse.SetActive(true);
    }
}