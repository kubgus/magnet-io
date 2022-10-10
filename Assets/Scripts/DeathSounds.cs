using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSounds : MonoBehaviour
{
    [SerializeField] AudioSource death;

    public void Die()
    {
        death.Play();
    }
}
