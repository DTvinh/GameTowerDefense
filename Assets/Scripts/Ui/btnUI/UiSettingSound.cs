using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiSettingSound : MonoBehaviour
{
    public Slider musicSlider;
    public Slider SFXSlider;

    void Start()
    {
        AddEventSlider();
        LoadUiSettingSound();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void AddEventSlider()
    {
        if (musicSlider != null)
        {

            musicSlider.onValueChanged.AddListener(AudioManager.Instance.MusicVolume);
        }
        if (SFXSlider != null)
        {

            SFXSlider.onValueChanged.AddListener(AudioManager.Instance.SFXVolume);
        }

    }



    private void LoadUiSettingSound()
    {
        musicSlider.value = SaveSystem.GetData().settingSound.musicVolume;
        SFXSlider.value = SaveSystem.GetData().settingSound.sfxVolume;
    }






}


