using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
    public Toggle fullscreenToggle;

    public void Save()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
        PlayerPrefs.SetInt("Fullscreen", fullscreenToggle.isOn ? 1 : 0);

        PlayerPrefs.Save();

        Debug.Log("Settings salvate");
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        }

        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        }

        if (PlayerPrefs.HasKey("Fullscreen"))
        {
            fullscreenToggle.isOn = PlayerPrefs.GetInt("Fullscreen") == 1;
        }

        Debug.Log("Settings caricate");
    }
}