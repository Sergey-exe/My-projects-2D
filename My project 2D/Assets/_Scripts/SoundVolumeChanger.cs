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
    [SerializeField] private AudioMixerGroup _audioMixerGroup;

    private bool isMute = false;

    public void ToggleSound(bool enabled)
    {
        isMute = enabled;

        if (isMute == false)
            _audioMixerGroup.audioMixer.SetFloat(MasterVolume, 0);
        else
            _audioMixerGroup.audioMixer.SetFloat(MasterVolume, -80);
    }

    public void ChangeVolumeMaster(float volume)
    {
        if (isMute == false)
            _audioMixer.SetFloat(MasterVolume, Mathf.Lerp(-80, 0, volume));
    }

    public void ChangeVolumeButton(float volume)
    {
        _audioMixer.SetFloat(ButtonsVolume, Mathf.Lerp(-80, 0, volume));
    }

    public void ChangeVolumeSoundtrack(float volume)
    {
        _audioMixer.SetFloat(SoundtrackVolume, Mathf.Lerp(-80, 0, volume));
    }
}
