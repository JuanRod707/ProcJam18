using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Code.IO;
using UnityEngine;

[Serializable]
public class ConfigurationSet
{
    public const string Filename = "Config.xml";

    public float MasterVolume;
    public float MusicVolume;
    public float EffectsVolume;
    public float AmbienceVolume;
    public float UIVolume;
    
    public static void SaveConfig(ConfigurationSet config)
    {
        FileManagement.SaveFile(config, Filename);
    }

    public static ConfigurationSet LoadConfig()
    {
        try
        {
            return FileManagement.OpenSaves<ConfigurationSet>(Filename) as ConfigurationSet;
        }
        catch
        {
            return new ConfigurationSet();
        }
    }
}
