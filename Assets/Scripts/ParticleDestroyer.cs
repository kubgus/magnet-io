using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroyer : MonoBehaviour
{
    ParticleSystem p;
    void Start()
    {
        p = GetComponent<ParticleSystem>();
    }
    void Update()
    {
        if (!p.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
