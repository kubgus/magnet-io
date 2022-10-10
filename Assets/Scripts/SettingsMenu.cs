using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] Toggle VFXCheckbox;

    public void UpdateSettings()
    {
        if (VFXCheckbox.isOn)
        {
            PlayerPrefs.SetInt("vfx", 0);
        } else
        {
            PlayerPrefs.SetInt("vfx", 1);
        }

        print(PlayerPrefs.GetInt("vfx"));
    }

}
