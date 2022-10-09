using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ElectronController : MonoBehaviour
{

    /// <summary>
    /// Force that the object moves to the follow object
    /// </summary>
    public float force;
    public float attractModeForce;
    /// <summary>
    /// Max distance
    /// </summary>
    public float distance;
    /// <summary>
    /// Adds a bit of randomness
    /// </summary>
    public float instability;

    [SerializeField] List<GameObject> nearbyPlayers;
    [SerializeField] Transform deathParticles;
    [SerializeField] Transform spawnParticles;
    bool spawnedSpawnParticles;

    private void Update()
    {
        if (!spawnedSpawnParticles)
        {
            SpawnSpawnParticles();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!nearbyPlayers.Contains(other.gameObject) && other.gameObject.CompareTag("Player"))
        {
            nearbyPlayers.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (nearbyPlayers.Contains(other.gameObject) && other.gameObject.CompareTag("Player"))
        {
            nearbyPlayers.Remove(other.gameObject);
        }
    }

    public void SpawnSpawnParticles()
    {
        spawnedSpawnParticles = true;
        ParticleSystem p = Instantiate(spawnParticles, transform.position, transform.rotation).GetComponent<ParticleSystem>();
#pragma warning disable CS0618 // Type or member is obsolete
        p.startColor = GetComponent<SpriteRenderer>().color;
#pragma warning restore CS0618 // Type or member is obsolete
        p.Play();
    }
    public void SpawnDeathParticles()
    {
        ParticleSystem p = Instantiate(deathParticles, transform.position, transform.rotation).GetComponent<ParticleSystem>();
#pragma warning disable CS0618 // Type or member is obsolete
        p.startColor = GetComponent<SpriteRenderer>().color;
#pragma warning restore CS0618 // Type or member is obsolete
        p.Play();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        foreach (GameObject c in nearbyPlayers)
        {
            Transform e = null;
            if (c != null)
            {
                e = c.transform;
            }

            // Calculated distance between electron and object
            float _distance = Vector2.Distance(transform.position, e.transform.position);

            AttractMode mode = e.gameObject.GetComponent<AttractMode>();

            //// Calculate position
            //Vector2 pos = Vector2.MoveTowards(e.transform.position, transform.position, Mathf.Max(0, force * (distance - Vector2.Distance(e.transform.position, transform.position))));

            //// Move towards the follow object
            //e.transform.position = new(pos.x, pos.y);

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            Vector2 f = new Vector2();
            // =========================================================================================
            // This is extremly poorly written but I found no other way
            try
            {
                if (e.gameObject == mode.gameObject && mode.attractMode)
                {
                    f = (e.position - transform.position) * Mathf.Max(0, attractModeForce * (distance - _distance));
                }
                else
                {
                    f = (e.position - transform.position) * Mathf.Max(0, force * (distance - _distance));
                }
            }
            catch
            {
                f = (e.position - transform.position) * Mathf.Max(0, force * (distance - _distance));
            }
            // Please forgive me, God
            // =========================================================================================

            if (Random.Range(0,instability) == 0)
            {
                rb.AddForce(f);
            }
        }
    }
}
