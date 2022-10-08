using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Health
    [Range(0f, 100f)]
    public float s;

    [SerializeField] Collider2D pBase;
    [SerializeField] float minSize;
    [SerializeField] float maxSize;
    [SerializeField] float shrinkPerSecond;
    [SerializeField] float growInBasePerSecond;
    [SerializeField] float shrinkInEnemyBasePerSecond;

    bool inBase;
    bool inEnemyBase;

    // Update is called once per frame
    void Update()
    {
        // Get size
        float size = s / 100 * (maxSize - minSize) + minSize;

        // Set scale based on health
        transform.localScale = new(Mathf.Clamp(size, minSize, maxSize), Mathf.Clamp(size, minSize, maxSize));


        if (inBase)
        {
            s += Time.deltaTime * growInBasePerSecond;
            s = Mathf.Min(s, 100);
        }
        else if (inEnemyBase)
        {
            s -= Time.deltaTime * shrinkInEnemyBasePerSecond;
        }
        else
        {
            s -= Time.deltaTime * shrinkPerSecond;
            s = Mathf.Max(s, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
    private void OnTriggerExit2D(Collider2D collision)
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
}