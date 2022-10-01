using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundConfigurator : MonoBehaviour
{
    [SerializeField]private AudioSource _audioSource;
    [SerializeField] private Slider _audioVolumeSlider;


    private void Awake()
    {
        _audioSource.volume = 0.5f;

        _audioVolumeSlider.onValueChanged.AddListener(ChangeVolume);

        _audioVolumeSlider.value = _audioSource.volume;
    }


    private void ChangeVolume(float volume)
    {
        _audioSource.volume = volume;
    }


    
}
