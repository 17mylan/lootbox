using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UltimateLootBox : MonoBehaviour
{
    public GameObject lootBox;
    public GameObject Open;
    public GameObject Exit;
    public GameObject Particles;
    public GameObject UltimateCard;
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
    }
    public void LootSpawnn()
    {
        UltimateCard.SetActive(true);
        Exit.SetActive(true);
    }
}
