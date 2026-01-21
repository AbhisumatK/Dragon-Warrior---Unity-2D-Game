using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuVolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundSlider;

    private void Start()
    {
        float savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        musicSlider.value = savedMusicVolume;
        SetMusicVolume(savedMusicVolume);

        float savedSoundVolume = PlayerPrefs.GetFloat("SoundVolume", 1f);
        soundSlider.value = savedSoundVolume;
        SetSoundVolume(savedSoundVolume);
    }

    public void SetMusicVolume(float value)
    {
        musicSource.volume = value;
        PlayerPrefs.SetFloat("MusicVolume", value);
    }
    public void SetSoundVolume(float value)
    {
        PlayerPrefs.SetFloat("SoundVolume", value);
    }
}