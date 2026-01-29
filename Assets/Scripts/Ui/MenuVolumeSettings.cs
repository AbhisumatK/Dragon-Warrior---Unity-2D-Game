using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuVolumeSettings : MonoBehaviour
{
    public void SoundVolume()
    {
        SoundManager.instance.changeSoundVolume(0.2f);
    }

    public void MusicVolume()
    {
        SoundManager.instance.changeMusicVolume(0.2f);
    }
}