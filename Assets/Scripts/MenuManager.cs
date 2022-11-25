using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject Options;
    public GameObject Profile;

    public GameObject GoldButton;

    public void ButtonClick(string _String)
    {
        if (_String == "Options")
        {
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;
            if (sceneName == "Main")
            {
                Profile.SetActive(false);
                GoldButton.SetActive(false);
            }
            Options.SetActive(true);
        }
        if (_String == "CloseOptions")
        {
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;
            if (sceneName == "Main")
            {
                GoldButton.SetActive(true);
            }
            Options.SetActive(false);
        }
        if (_String == "Profile")
        {
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;
            if (sceneName == "Main")
            {
                Profile.SetActive(true);
                GoldButton.SetActive(false);
            }
            Options.SetActive(false);
        }
        if (_String == "CloseProfile")
        {
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;
            if (sceneName == "Main")
            {
                GoldButton.SetActive(true);
            }
            Profile.SetActive(false);
        }
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
