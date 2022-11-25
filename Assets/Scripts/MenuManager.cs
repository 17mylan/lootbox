using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject Options;
    public GameObject Profile;

    public GameObject GoldButton;

    public void ButtonClick(string _String)
    {
        if (_String == "Options")
        {
            Profile.SetActive(false);
            GoldButton.SetActive(false);
            Options.SetActive(true);
        }
        if (_String == "CloseOptions")
        {
            Options.SetActive(false);
            GoldButton.SetActive(true);
        }
        if (_String == "Profile")
        {
            Profile.SetActive(true);
            GoldButton.SetActive(false);
            Options.SetActive(false);
        }
        if (_String == "CloseProfile")
        {
            Profile.SetActive(false);
            GoldButton.SetActive(true);
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
}
