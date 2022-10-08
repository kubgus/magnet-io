using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Health
    [Range(0f, 100f)]
    public float s;
    [SerializeField] GameObject basePrefab;
    [SerializeField] Collider2D pBase;
    [SerializeField] float minSize;
    [SerializeField] float maxSize;
    [SerializeField] float shrinkPerSecond;
    [SerializeField] float shrinkWithAttractMode;
    [SerializeField] float shrinkInEnemyBasePerSecond;
    [SerializeField] float growInBasePerSecond;

    bool inBase;
    bool inEnemyBase;

    AttractMode mode;

    private void Start()
    {
        mode = GetComponent<AttractMode>();
        pBase = Instantiate(basePrefab, transform.position, Quaternion.identity).GetComponent<PolygonCollider2D>();
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
            s += Time.deltaTime * growInBasePerSecond * GetShrinkSpeed();
            s = Mathf.Min(s, 100);
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
        if (collision == pBase)
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
        if (mode.attractMode)
        {
            return shrinkWithAttractMode;
        }
        return 1;
    }
}