using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ConfigLoader : MonoBehaviour
{
    public AudioMixer Mixer;

    void Start()
    {
        var config = ConfigurationSet.LoadConfig();
        
        Mixer.SetFloat("MasterVol", config.MasterVolume);
        Mixer.SetFloat("AmbVol", config.AmbienceVolume);
        Mixer.SetFloat("MusicVol", config.MusicVolume);
        Mixer.SetFloat("SfxVol", config.EffectsVolume);
        Mixer.SetFloat("UIVol", config.UIVolume);
    }
}