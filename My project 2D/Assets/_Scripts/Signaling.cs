using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _speed;

    private Coroutine _coroutine = null;

    public void StartCounter(int targetValue = 1)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(CounterCountValue(targetValue));
    }

    private IEnumerator CounterCountValue(int targetValue)
    {
        int maxValue = 1;

        if(targetValue == maxValue)
            _audioSource.Play();

        while (_audioSource.volume != targetValue)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetValue, _speed * Time.deltaTime);

            yield return null;
        }
    }
}
