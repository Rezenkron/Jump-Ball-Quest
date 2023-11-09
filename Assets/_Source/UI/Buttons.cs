using UnityEngine;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour
{
    public void LoadSceneWithIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
}
