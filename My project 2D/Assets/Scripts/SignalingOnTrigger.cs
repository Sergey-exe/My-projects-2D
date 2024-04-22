using System;
using System.Collections;
using UnityEngine;

public class SignalingOnTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _speed;

    private Coroutine _coroutine = null;
    private bool _hasRogue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<HeroKnight>())
        {
            _audioSource.Play();

            _hasRogue = true;

            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(CounterCountValue());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<HeroKnight>())
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(CounterCountValue(-1));
        }    
    }

    private IEnumerator CounterCountValue(int direction = 1, float delay = 0.1f)
    {
        var wait = new WaitForSeconds(delay);

        int minValue = 0;
        int maxValue = 1;

        while (_hasRogue)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, maxValue, direction * _speed * Time.deltaTime);

            if (_audioSource.volume == minValue)
            {
                _audioSource.Stop();
                _hasRogue = false;

                StopCoroutine(_coroutine);
            }
            else if (_audioSource.volume == maxValue)
            {
                StopCoroutine(_coroutine);
            }

            yield return wait;
        }
    }
}
