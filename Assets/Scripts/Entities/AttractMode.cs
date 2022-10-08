using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class AttractMode : MonoBehaviour
{
    public bool attractMode;

    private void Start()
    {
        attractMode = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            attractMode = true;
        }
        else
        { 
            attractMode = false;
        }

    }
}
