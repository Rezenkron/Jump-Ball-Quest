using UnityEngine;
using UnityEngine.UI;

public class LevelsMenuBootstrapper : MonoBehaviour
{
    [SerializeField] Button[] buttons = new Button[0];

    void Start()
    {
        for(int i = 1; i <= buttons.Length; i++)
        {
            if(PlayerPrefs.HasKey("Level" + i))
            {
                if(PlayerPrefs.GetInt("Level" + i) == 1)
                {
                    buttons[i].interactable = true;
                }
            }
        }
    }
}
