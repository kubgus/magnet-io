using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColorBehaviour : MonoBehaviour
{
    [SerializeField] float s = 1;
    [SerializeField] float v = 1;

    void Start()
    {
        Color c = Color.HSVToRGB(Random.Range(0f,100000000f) / 100000000f,s,v);
        if (GetComponent<SpriteRenderer>())
        {
            GetComponent<SpriteRenderer>().color = c;
        }
        if (GetComponent<ParticleSystem>())
        {
#pragma warning disable CS0618 // Type or member is obsolete
            GetComponent<ParticleSystem>().startColor = c;
#pragma warning restore CS0618 // Type or member is obsolete
            GetComponent<ParticleSystem>().Play();
        }
    }
}
