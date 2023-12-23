using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingBtn : MonoBehaviour
{
    [SerializeField] private GameObject panelSound;
    [SerializeField] private AudioSource backgroundMusic; 
    private float volume;
    [SerializeField] private Slider sliderVolume;

    private void Start()
    {
        if (panelSound == null || backgroundMusic == null)
        {
            Debug.LogError("Please assign panelSound and backgroundMusic in the Inspector!");
        }
        PlayBackgroundMusic();
    }
    private void Update()
    {
        SetBackgroundMusicVolume();
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void SettingSound()
    {
        panelSound.SetActive(true);
    }
    public void ExitPanelSound()
    {
        panelSound.SetActive(false);
    }
    public void ToggleBackgroundMusic()
    {
        if (backgroundMusic.isPlaying)
        {
            backgroundMusic.Pause();
        }
        else
        {
            backgroundMusic.Play();
        }
    }

    public void SetBackgroundMusicVolume()
    {
        volume = sliderVolume.value;
        backgroundMusic.volume = volume;

    }
     private void PlayBackgroundMusic()
    {
        if (backgroundMusic.clip == null)
        {
            Debug.LogError("Please assign an audio clip to the backgroundMusic AudioSource!");
            return;
        }

        backgroundMusic.Play();
    }
    public void OpenURL()
    {
        Application.OpenURL("https://www.facebook.com/MultimediaTechHust");
    }
}
