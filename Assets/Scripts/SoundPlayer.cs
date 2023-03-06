using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] _damageSnd;

    private Health _health;
    private AudioSource _audioPlayer;

    private void Start()
    {
        _health = GetComponent<Health>();
        _audioPlayer = GetComponent<AudioSource>();
        _health.OnHealthChanged += DamageAudioPlayer;
    }


    private void DamageAudioPlayer(float damage, int currentHp, int maxHp)
    {
        if (_damageSnd.Length > 0 && damage > 0)
        {
            int randInd = Random.Range(0, _damageSnd.Length);
            _audioPlayer.PlayOneShot(_damageSnd[randInd]);
        }
    }
    private void Destroy()
    {
        _health.OnHealthChanged -= DamageAudioPlayer;
    }

    // private void OnEnable()
    // {
    //     _health.OnHealthChanged += DamageAudioPlayer;
    // }

    // private void OnDisable()
    // {
    //     _health.OnHealthChanged -= DamageAudioPlayer;
    // }
}
