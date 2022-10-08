using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float s;

    [SerializeField] Collider2D home;
    bool atHome;
    bool inEnemyBase;

    [SerializeField] float shrinkPerSecond;
    [SerializeField] float growInBasePerSecond;
    [SerializeField] float shrinkInEnemyBasePerSecond;
    [SerializeField] float minSize;
    [SerializeField] float maxSize;

    public float baseSize;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        // Get size
        float size = s / 100 * (maxSize - minSize) + minSize;

        s = Mathf.Clamp(s, 0, 100);

        // Set scale based on health
        transform.localScale = new(Mathf.Clamp(size * baseSize, minSize * baseSize, maxSize * baseSize), Mathf.Clamp(size * baseSize, minSize * baseSize, maxSize * baseSize));


        if (atHome)
        {
            s += Time.deltaTime * growInBasePerSecond / baseSize;
        }
        else if (inEnemyBase)
        {
            s -= Time.deltaTime * shrinkInEnemyBasePerSecond / baseSize;
        }
        else
        {
            s -= Time.deltaTime * shrinkPerSecond / baseSize;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Base"))
        {
            if (collision == home)
            {
                atHome = true;
            }
            else
            {
                inEnemyBase = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == home)
        {
            if (collision == home)
            {
                atHome = false;
            }
            else
            {
                inEnemyBase = false;
            }
        }
    }
}