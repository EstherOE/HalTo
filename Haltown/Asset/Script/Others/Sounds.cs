using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sounds : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.GetFloat("musicVolume", volumeSlider.value);
            onLoad();
        }

        else
        {
            onLoad();
        }
    }

    private void onLoad()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    public void OnChange()
    {
        AudioListener.volume = volumeSlider.value;
        OnSave();
    }

    private void OnSave()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

    
}
