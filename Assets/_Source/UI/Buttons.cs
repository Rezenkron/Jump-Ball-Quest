using UnityEngine;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour
{
    public void BackToMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
