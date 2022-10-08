using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class AttractMode : MonoBehaviour
{
    public bool attractMode;
    [SerializeField] PostProcessProfile profile;
    ChromaticAberration ab;
    [SerializeField] float smoothSpeed;

    private void Start()
    {
        attractMode = false;
        profile.TryGetSettings(out ab);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            attractMode = true;
            ab.intensity.value = Mathf.Lerp(ab.intensity.value, 1, smoothSpeed);
        }
        else
        { 
            attractMode = false;
            ab.intensity.value = Mathf.Lerp(ab.intensity.value, 0, smoothSpeed);
        }

    }
}
