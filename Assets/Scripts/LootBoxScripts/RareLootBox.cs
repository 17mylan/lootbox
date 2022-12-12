using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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



    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Open", true);

            Invoke("ParticlesSystem", .5f);
            Invoke("LootSpawnn", .5f);
            Invoke("DestroyBox", 2.0f);

        }

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

            LootSpawnn();

            Open.SetActive(false);
            Exit.SetActive(true);
        }

        if (_String == "LeaveScene")
        {
            SceneManager.LoadScene("Main");
        }
        //Invoke("LootSpawnn", 2.0f);



    }

    public void LootSpawnn()
    {
        float randomNum = Random.Range(0, 100);
        float randomNum2 = Random.Range(1, 3);

        if (randomNum <= 60)
        {
            if (randomNum2 == 1)
            {
                Commun1.SetActive(true);
            }
            if (randomNum2 == 2)
            {
                Commun2.SetActive(true);
            }
            if (randomNum2 == 3)
            {
                Commun3.SetActive(true);
            }

            //card1.SetActive(true);
        }

        if (randomNum > 60 && randomNum <= 98)
        {
            if (randomNum2 == 1)
            {
                Rare1.SetActive(true);
            }
            if (randomNum2 == 2)
            {
                Rare2.SetActive(true);
            }
            if (randomNum2 == 3)
            {
                Rare3.SetActive(true);
            }

            //card2.SetActive(true);
        }

        if (randomNum > 98 && randomNum <= 100)
        {
            if (randomNum2 == 1)
            {
                Epic1.SetActive(true);
            }
            if (randomNum2 == 2)
            {
                Epic2.SetActive(true);
            }
            if (randomNum2 == 3)
            {
                Epic3.SetActive(true);
            }

            //card3.SetActive(true);
        }

        Exit.SetActive(true);
    }
}
