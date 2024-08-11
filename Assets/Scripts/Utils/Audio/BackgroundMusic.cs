using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{

    [Header("----- Audio Source-----")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource cartSource;

    [Header("----- Audio Clip-----")]
    public AudioClip backgroundMusic;
    public AudioClip cartSfx;

    private void Start()
    {
        musicSource.clip = backgroundMusic;
        cartSource.clip = cartSfx;
        musicSource.Play();
        cartSource.Play();
    }

}
