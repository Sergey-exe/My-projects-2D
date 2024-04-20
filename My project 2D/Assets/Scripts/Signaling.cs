using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _delay = 0;
    [SerializeField] private float _step = 0;

    private Coroutine coroutine = null;

    public void StartSignaling()
    {
        _audioSource.Play();

        ChangeVolume();
    }

    public void ChangeVolume(int direction = 1)
    {
        if(coroutine != null)
            StopCoroutine(coroutine);

        coroutine = StartCoroutine(CounterSoundVolume(direction));
    }

    private IEnumerator CounterSoundVolume(int direction)//////
    {
        var wait = new WaitForSeconds(_delay);

        int numberIterations = Convert.ToInt32(1 / _step);
        int minVolume = 0;
        int maxVolume = 1;

        for (int i = 0; i < numberIterations; i++)
        {
            _audioSource.volume += _step * direction;

            if (_audioSource.volume == minVolume) 
            {
                _audioSource.Stop();
                StopCoroutine(coroutine);
            }
            else if (_audioSource.volume == maxVolume)
            {
                StopCoroutine(coroutine);
            }

            yield return wait;
        }
    }
}
