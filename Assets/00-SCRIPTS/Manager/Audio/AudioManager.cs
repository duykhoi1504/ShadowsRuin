using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private Sound[] sfxSounds, musicSounds;
    [SerializeField] private AudioSource sfxSource, musicSource;


    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;

    }

    private void Start()
    {
        PlayerMusic(CONTANST.theme);
    }


    public void PlayerSFXPitch(string name){
        sfxSource.pitch=Random.Range(.8f, 1.2f);
        PlaySFX(name);
    }

    public void PlayerMusic(string name)
    {
        
        Sound soundTemp = null;
        foreach (Sound sound in musicSounds)
        {
            if (sound.name == name)
            {
                soundTemp = sound;
                break;
            }
        }

        if (soundTemp != null)
        {
            musicSource.clip = soundTemp.clip;

            musicSource.Play();
        }
        else
            Debug.Log(name + " loi khong tim thay sound");

    }
    public void PlaySFX(string name)
    {
        
        Sound soundTemp = null;
        foreach (Sound sound in sfxSounds)
        {
            if (sound.name == name)
            {
                soundTemp = sound;
                break;
            }
        }

        if (soundTemp != null)
        {
            sfxSource.PlayOneShot(soundTemp.clip);
        }
        else
            Debug.Log(name + " loi khong tim thay sound");

    }
    public void MusicVolumn(float _volumn)
    {
        musicSource.volume = _volumn;
    }
    public void SFXVolumn(float _volumn)
    {
        sfxSource.volume = _volumn;
    }
    public void PlaySFXClick()=>PlaySFX(CONTANST.open);
    public void PlaySFXClose()=>PlaySFX(CONTANST.close);
    public void PlaySFXBuy()=>PlaySFX(CONTANST.buy);
    public void PlaySFXEquip()=>PlaySFX(CONTANST.equip);
}

