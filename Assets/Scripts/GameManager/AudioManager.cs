using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update


    public AudioSource musicAudioSource;
    public AudioSource SFXSource;


    public AudioClip musicClip;


    public AudioClip arrowClicp;
    public AudioClip FileBall;
    public AudioClip linghtingTowerClip;
    public AudioClip fireBallExplosion;
    public AudioClip youLose;
    public AudioClip victory;

    public AudioClip swordClip;
    public AudioClip enemyHitClip;




    // public AudioClip hitClip;
    // public AudioClip moveClip;
    // public AudioClip trainMoveClip;
    public static AudioManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        musicAudioSource.clip = musicClip;
        musicAudioSource.Play();
        LoadSettingVolume(SaveSystem.GetData().settingSound);
        Debug.Log(SaveSystem.GetData().settingSound.musicVolume);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void PlaySFX(AudioClip audioSFX)
    {
        SFXSource.PlayOneShot(audioSFX);
    }
    public void MusicVolume(float volume)
    {
        if (volume <= 0)
        {
            musicAudioSource.mute = false;
        }
        musicAudioSource.volume = volume;

    }
    public void SFXVolume(float volume)
    {
        if (volume <= 0)
        {
            SFXSource.mute = false;
        }
        SFXSource.volume = volume;

    }

    public void LoadSettingVolume(SettingSound setting)
    {
        musicAudioSource.volume = setting.musicVolume;
        SFXSource.volume = setting.sfxVolume;

    }
    public void SaveSettingVolume(ref SettingSound setting)
    {
        setting.musicVolume = musicAudioSource.volume;
        setting.sfxVolume = SFXSource.volume;
    }

}
[System.Serializable]
public class SettingSound
{
    public float musicVolume;
    public float sfxVolume;

}
