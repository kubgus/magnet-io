using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBehaviour : MonoBehaviour
{
    [SerializeField] float x;
    [SerializeField] float y;
    [SerializeField] float z;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(x, y, z);
    }
}
