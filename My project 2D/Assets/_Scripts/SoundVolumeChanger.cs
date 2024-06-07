using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundVolumeChanger : MonoBehaviour
{
    private const string MasterVolume = nameof(MasterVolume);
    private const string ButtonsVolume = nameof(ButtonsVolume);
    private const string SoundtrackVolume = nameof(SoundtrackVolume);

    [SerializeField] private AudioMixer _audioMixer;

    private bool isMute = false;

    public void ToggleSound(bool enabled)
    {
        isMute = enabled;

        if (isMute == false)
            _audioMixer.SetFloat(MasterVolume, 0);
        else
            _audioMixer.SetFloat(MasterVolume, -80);
    }

    public void ChangeVolumeMaster(float volume)
    {
        if (isMute == false)
            ChangeVolume(volume, MasterVolume);
    }

    public void ChangeVolumeButton(float volume)
    {
        ChangeVolume(volume, ButtonsVolume);
    }

    public void ChangeVolumeSoundtrack(float volume)
    {
        ChangeVolume(volume, SoundtrackVolume);
    }

    public void ChangeVolume(float volume, string nameParameter)
    {
        _audioMixer.SetFloat(nameParameter, Mathf.Log10(volume) * 20);
    }
}
