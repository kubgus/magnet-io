using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField] float x;
    [SerializeField] float y;
    void Start()
    {
       transform.position = new Vector2(Random.Range(-x,x), Random.Range(-y, y)); 
    }

}
