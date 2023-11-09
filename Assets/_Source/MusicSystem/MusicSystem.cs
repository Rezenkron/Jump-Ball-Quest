using UnityEngine;

public class MusicSystem : MonoBehaviour
{
    void Awake()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

        if (PlayerPrefs.HasKey(MusicVolumeAdjuster.VOLUME_PREFS_NAME))
        {
            GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat(MusicVolumeAdjuster.VOLUME_PREFS_NAME);
        }
    }
}
