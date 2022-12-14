using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public Transform owner;

    [SerializeField] float startSize = 5f;
    [SerializeField] float smoothPerSecond;
    [SerializeField] float electronBonus;
    [SerializeField] GameObject particles;
    [SerializeField] AudioSource pickup;
    [SerializeField] float audioDistance;
    float level;

    private void Start()
    {
        level = 0;
        SpawnDeathParticles();
    }

    private void Update()
    {
        if (owner == null)
        {
            SpawnDeathParticles();
            Destroy(gameObject);
        }

        float trueScale = Mathf.Lerp(transform.localScale.x, level + startSize, Time.deltaTime * smoothPerSecond);
        transform.localScale = new Vector2(trueScale, trueScale);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Electron") && other.GetType() == typeof(CircleCollider2D))
        {
            other.gameObject.GetComponent<ElectronController>().SpawnDeathParticles();
            try
            {
                if (Vector2.Distance(GameObject.Find("Player").transform.position, other.transform.position) < audioDistance)
                {
                    pickup.Play();
                }
            } catch { }
            Destroy(other.gameObject);
            level += electronBonus;
        }
    }

    private void SpawnDeathParticles()
    {
        ParticleSystem p = Instantiate(particles, transform.position,transform.rotation).GetComponent<ParticleSystem>();
#pragma warning disable CS0618 // Type or member is obsolete
        p.startColor = GetComponent<SpriteRenderer>().color;
#pragma warning restore CS0618 // Type or member is obsolete
        p.Play();
    }
}