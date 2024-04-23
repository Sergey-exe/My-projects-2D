using System;
using System.Collections;
using UnityEngine;

public class SignalingOnTrigger : MonoBehaviour
{
    [SerializeField] private Signaling _signaling;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<HeroKnight>(out HeroKnight rogue))
            _signaling.StartCounter();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<HeroKnight>(out HeroKnight rogue))
            _signaling.StartCounter(0);
    }
}
