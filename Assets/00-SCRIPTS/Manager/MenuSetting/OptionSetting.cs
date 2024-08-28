using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionSetting : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Slider sliderMusic;
    [SerializeField] Slider sliderSFX;
    [SerializeField] AudioManager audio;
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource sfx;


    void Start()
    {
        audio = FindAnyObjectByType<AudioManager>();
        sfx = audio.transform.GetChild(0).GetComponent<AudioSource>();
        music = audio.transform.GetChild(1).GetComponent<AudioSource>();

        sliderMusic.value = music.volume;
        sliderSFX.value =sfx.volume;

    }

    // Update is called once per frame
    void Update()
    {
        AudioManager.Instant.MusicVolumn( sliderMusic.value);
        AudioManager.Instant.SFXVolumn(  sliderSFX.value);


    }
}
