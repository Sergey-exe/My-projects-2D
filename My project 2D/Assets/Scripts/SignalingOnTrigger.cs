using UnityEngine;

public class SignalingOnTrigger : MonoBehaviour
{
    [SerializeField] private Signaling _signaling;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<HeroKnight>())
            _signaling.StartSignaling();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        int reverseDirection = -1;

        if (collision.GetComponent<HeroKnight>())
            _signaling.ChangeVolume(reverseDirection);
    }
}
