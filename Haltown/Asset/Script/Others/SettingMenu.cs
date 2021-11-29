using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMenu : MonoBehaviour
{

    public void SetFullScreen( bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }

    public void SetQuality(int value)
    {
        QualitySettings.SetQualityLevel(value);
    }
}
