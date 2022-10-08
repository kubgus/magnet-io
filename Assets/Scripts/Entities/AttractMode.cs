using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class AttractMode : MonoBehaviour
{
    public bool attractMode;

    [SerializeField] PostProcessProfile profile;
    [SerializeField] float smoothSpeed;

    ChromaticAberration ab;
    ColorGrading cg;
    Bloom bl;

    private void Start()
    {
        attractMode = false;
        profile.TryGetSettings(out ab);
        profile.TryGetSettings(out cg);
        profile.TryGetSettings(out bl);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            attractMode = true;
            ab.intensity.value = Mathf.Lerp(ab.intensity.value, 1, smoothSpeed);
            cg.contrast.value = Mathf.Lerp(cg.contrast.value, 14, smoothSpeed);
            bl.softKnee.value = Mathf.Lerp(bl.softKnee.value, 0.61f, smoothSpeed);
        }
        else
        { 
            attractMode = false;
            ab.intensity.value = Mathf.Lerp(ab.intensity.value, 0, smoothSpeed);
            cg.contrast.value = Mathf.Lerp(cg.contrast.value, 7, smoothSpeed);
            bl.softKnee.value = Mathf.Lerp(bl.softKnee.value, 0.332f, smoothSpeed);
        }

    }
}
