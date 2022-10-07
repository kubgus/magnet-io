using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColorBehaviour : MonoBehaviour
{
    [SerializeField] float s = 1;
    [SerializeField] float v = 1;

    void Start()
    {
        GetComponent<SpriteRenderer>().color = Color.HSVToRGB(Random.Range(0f,100000000f) / 100000000f,s,v);
    }
}
