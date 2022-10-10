using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingToggle : MonoBehaviour
{
    PostProcessVolume vol;

    private void Start()
    {
        vol = GetComponent<PostProcessVolume>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("vfx") == 1)
        {
            vol.enabled = false;
        } else
        {
            vol.enabled = true;
        }
    }
}
