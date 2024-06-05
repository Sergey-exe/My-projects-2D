using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource1;
    [SerializeField] private AudioSource _audioSource2;
    [SerializeField] private AudioSource _audioSource3;
    [SerializeField] private float minPitch = 0.5f;
    [SerializeField] private float maxPitch = 1.5f;

    public void PlaySound1()
    {
        _audioSource1.pitch = Random.Range(minPitch, maxPitch);
        _audioSource1.Play();
    }

    public void PlaySound2()
    {
        _audioSource2.pitch = Random.Range(minPitch, maxPitch);
        _audioSource2.Play();
    }

    public void PlaySound3()
    {
        _audioSource3.Play();
    }
}
