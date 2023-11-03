using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBootstrapper : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button shopButton;

    private MenuButtonsMethods menuButtons;

    private void Awake()
    {
        menuButtons = new MenuButtonsMethods();
    }

    private void Start()
    {
        menuButtons.Play(playButton);
        menuButtons.Settings(settingsButton);
        menuButtons.Shop(shopButton);
    }

}
