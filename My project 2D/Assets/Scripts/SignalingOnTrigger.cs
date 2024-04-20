using UnityEngine;

public class SignalingOnTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _speed;

    private bool _isPlaying;

    private void Update()
    {
        float maxSound = 1.0f;

        if (_isPlaying)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, maxSound, _speed * Time.deltaTime);
        }
        else
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, maxSound, -_speed * Time.deltaTime);
        }

        if(_audioSource.volume == 0)
        {
            _audioSource.Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<HeroKnight>())
        {
            _audioSource.Play();
            _isPlaying = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<HeroKnight>())
            _isPlaying = false;
    }
}
