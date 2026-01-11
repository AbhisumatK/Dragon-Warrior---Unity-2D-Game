using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance{ get; private set; }
    private AudioSource audioSource;
    private AudioSource musicSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        musicSource = transform.GetChild(0).GetComponent<AudioSource>();

        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this && instance != null)
        {
            Destroy(gameObject);
        }

        changeMusicVolume(0);
        changeSoundVolume(0);
    }

    public void PlaySound(AudioClip _sound)
    {
        audioSource.PlayOneShot(_sound);
    }

    public void changeSoundVolume(float _change)
    {
        changeSourceVolume(1, "SoundVolume", _change, audioSource);
    }

    public void changeMusicVolume(float _change)
    {
        changeSourceVolume(0.5f, "MusicVolume", _change, musicSource);
    }

    private void changeSourceVolume(float baseVolume, string volumeName, float change, AudioSource source)
    {
        float currentVolume = PlayerPrefs.GetFloat(volumeName, 1);
        currentVolume += change;

        if(currentVolume > 1)
            currentVolume = 0;
        else if(currentVolume < 0)
            currentVolume = 1;

        float finalVolume = baseVolume * currentVolume;

        source.volume = finalVolume;
        PlayerPrefs.SetFloat(volumeName, currentVolume);
    }
}
