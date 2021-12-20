using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settingScript : MonoBehaviour
{

    [SerializeField] Slider volumeSlider;
    
    void Start()
    {
        if(PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume",1);
            Load();
        }   
        
        else
        {
            Load();
        }
    }
    
    public void changeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }
    
    private void Save()
    {
        PlayerPrefs.GetFloat("musicVolume");   
    }
    
    private void Load()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
    
    
     public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    
   
}


