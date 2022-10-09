using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Health
    [Range(0f, 100f)]
    public float s;
    public Collider2D pBase;
    [SerializeField] GameObject basePrefab;
    [SerializeField] float minSize;
    [SerializeField] float maxSize;
    [SerializeField] float shrinkPerSecond;
    [SerializeField] float shrinkWithAttractMode;
    [SerializeField] float shrinkInEnemyBasePerSecond;
    [SerializeField] float growInBasePerSecond;
    [SerializeField] float growInBaseSmoothSpeed;

    bool inBase;
    bool inEnemyBase;

    AttractMode mode;

    private void Start()
    {
        mode = GetComponent<AttractMode>();
        pBase = Instantiate(basePrefab, transform.position, Quaternion.identity).GetComponent<PolygonCollider2D>();
        pBase.transform.parent = GameObject.Find("Bases").transform;
        Color playerColor = GetComponent<SpriteRenderer>().color;
        pBase.GetComponent<SpriteRenderer>().color = new(playerColor.r, playerColor.g, playerColor.b, 0.7f);
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
}