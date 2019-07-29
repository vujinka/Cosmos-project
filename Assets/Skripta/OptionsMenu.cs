using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    //public AudioMixer audioMixer;
    private AudioSource audioSource;
    private float musicVolume = 0f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        audioSource.volume = musicVolume;
    }
    public void SetVolume(float volume)
    {
        //audioMixer.SetFloat("volume",volume);
        musicVolume = volume;
    }
}
