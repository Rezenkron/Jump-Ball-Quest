using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonsMethods
{
    public void Play(Button playButton)
    {
        playButton.onClick.AddListener(() => SceneManager.LoadScene(17));
    }
    
    public void Settings(Button settingsButton)
    {
        settingsButton.onClick.AddListener(() => SceneManager.LoadScene("Settings"));
    }

    public void Shop(Button shopButton)
    {
        shopButton.onClick.AddListener(() => SceneManager.LoadScene("Shop"));
    }
}
