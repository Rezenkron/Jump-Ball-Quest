using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private int nextSceneIndex;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((playerLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
