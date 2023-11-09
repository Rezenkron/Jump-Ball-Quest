using UnityEngine;

public class MusicChanger : MonoBehaviour
{
    [SerializeField] private AudioClip musicClip;

    private MusicSystem musicSystem;
    private AudioSource musicSource;
    void Awake()
    {
        musicSystem = FindObjectOfType<MusicSystem>();
        musicSource = musicSystem.GetComponent<AudioSource>();
        musicSource.clip = musicClip;
    }

    private void Start()
    {
        musicSource.Play();
    }
}
