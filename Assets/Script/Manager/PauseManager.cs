using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : Singleton<PauseManager>
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    private AudioSource musicSoure;
    [SerializeField] private AudioSource sfxSoure;

    private void Update()
    {
        MusicControl();
        SFXControl();
    }


    public void PauseGameButton()
    {
        Time.timeScale = 0f;
        musicSoure.Pause();
        sfxSoure.gameObject.SetActive(false);
       
    }
    public void SaveGameButton()
    {
        Save.SaveData();
    }
    public void ExitGameButton()
    {
        Application.Quit();
    }
    public void ExitPauseButton()
    {
        Time.timeScale = 1f;
        musicSoure.UnPause();
        sfxSoure.gameObject.SetActive(true);


    }


    void MusicVolume(float volume)
    {

        musicSoure.volume = volume;
    }

    void MusicControl()
    {
        if (musicSoure == null)
        {
            musicSoure = GameObject.Find("Music").GetComponent<AudioSource>();
            musicSlider.value = musicSoure.volume;
            musicSlider.onValueChanged.AddListener(MusicVolume);
        }
        
    }
    void SFXVolume(float volume)
    {

        sfxSoure.volume = volume;
    }

    void SFXControl()
    {
   
        sfxSlider.value = sfxSoure.volume;
        sfxSlider.onValueChanged.AddListener(SFXVolume);
    }

}
