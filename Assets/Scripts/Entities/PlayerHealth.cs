using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // Health
    [Range(0f, 100f)]
    public float s;
    public Collider2D pBase;

    // For enemyAI
    public bool inBase;
    public bool inEnemyBase;


    [SerializeField] GameObject basePrefab;
    [SerializeField] float minSize;
    [SerializeField] float maxSize;
    [SerializeField] float shrinkPerSecond;
    [SerializeField] float shrinkWithAttractMode;
    [SerializeField] float shrinkInEnemyBasePerSecond;
    [SerializeField] float growInBasePerSecond;
    [SerializeField] float growInBaseSmoothSpeed;

    AttractMode mode;
    [SerializeField] Transform particles;
    [SerializeField] AudioSource death;
    [SerializeField] float audioDistance;

    private void Start()
    {
        mode = GetComponent<AttractMode>();
        pBase = Instantiate(basePrefab, transform.position, Quaternion.identity).GetComponent<PolygonCollider2D>();
        pBase.transform.parent = GameObject.Find("Bases").transform;
        Color playerColor = GetComponent<SpriteRenderer>().color;
        pBase.GetComponent<SpriteRenderer>().color = new(playerColor.r, playerColor.g, playerColor.b, 0.7f);
        pBase.GetComponent<Base>().owner = transform;

    }

    // Update is called once per frame
    void Update()
    {
        // Get size
        float size = s / 100 * (maxSize - minSize) + minSize;

        // Set scale based on health
        transform.localScale = new(Mathf.Clamp(size, minSize, maxSize), Mathf.Clamp(size, minSize, maxSize));

        if (inBase)
        {
            s = Mathf.Lerp(s, 100, growInBaseSmoothSpeed);
        }
        else if (inEnemyBase)
        {
            s -= Time.deltaTime * shrinkInEnemyBasePerSecond * GetShrinkSpeed();
            s = Mathf.Max(s, 0);
        }
        else
        {
            s -= Time.deltaTime * shrinkPerSecond * GetShrinkSpeed();
            s = Mathf.Max(s, 0);
        }

        if (s <= 0)
        {
            SpawnDeathParticles();
            try
            {
                if (Vector2.Distance(GameObject.Find("Player").transform.position, transform.position) < audioDistance)
                {
                    GameObject.Find("DeathSounds").GetComponent<DeathSounds>().Die();
                }
            }
            catch { }
            //O 5 SEKUND TO INVOKNE FUNKCIU ABY TO NACITALO MAIN MENU
            if (gameObject.name == "Player")
            {
                FindObjectOfType<MainMenu>().LoadMenu(3f);
            }
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Base"))
        {
            if (collision == pBase)
            {
                inBase = true;
            }
            else
            {
                inEnemyBase = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Base"))
        {
            if (collision == pBase)
            {
                inBase = false;
            }
            else
            {
                inEnemyBase = false;
            }
        }
    }

    // Determine shrink speed with attracc mode
    float GetShrinkSpeed()
    {
        try
        {
            if (mode.attractMode)
            {
                return shrinkWithAttractMode;
            }
            return 1;
        } catch
        {
            return 1;
        }

    }

    private void SpawnDeathParticles()
    {
        ParticleSystem p = Instantiate(particles, transform.position, transform.rotation).GetComponent<ParticleSystem>();
#pragma warning disable CS0618 // Type or member is obsolete
        p.startColor = GetComponent<SpriteRenderer>().color;
#pragma warning restore CS0618 // Type or member is obsolete
        p.Play();
    }
}