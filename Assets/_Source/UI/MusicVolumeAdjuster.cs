using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeAdjuster : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    public const string VOLUME_PREFS_NAME = "Volume";
    private MusicSystem musicSystem;
    private AudioSource musicSourceAudio;

    private void Start()
    {
        musicSystem = FindObjectOfType<MusicSystem>();
        musicSystem.TryGetComponent<AudioSource>(out musicSourceAudio);
        musicSourceAudio.volume = PlayerPrefs.GetFloat(VOLUME_PREFS_NAME,0.5f);
        if(PlayerPrefs.HasKey(VOLUME_PREFS_NAME))
        {
            volumeSlider.value = PlayerPrefs.GetFloat(VOLUME_PREFS_NAME);
        }
    }

    public void AdjustAudio()
    {
        musicSourceAudio.volume = volumeSlider.value;
        PlayerPrefs.SetFloat(VOLUME_PREFS_NAME, volumeSlider.value);
    }
}
