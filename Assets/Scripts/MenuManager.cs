using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject Options;
    public GameObject Profile;

    public void ButtonClick(string _String)
    {
        if (_String == "Options")
        {
            Profile.SetActive(false);
            Options.SetActive(true);
        }
        if (_String == "CloseOptions")
        {
            Options.SetActive(false);
        }
        if (_String == "Profile")
        {
            Profile.SetActive(true);
            Options.SetActive(false);
        }
        if (_String == "CloseProfile")
        {
            Profile.SetActive(false);
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
}
