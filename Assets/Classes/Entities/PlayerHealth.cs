using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    /// <summary>
    /// Starting health amount
    /// </summary>
    [Range(0f, 100f)]
    public float s;

    public float sPerSecond;
    /// <summary>
    /// Minimum size of player
    /// </summary>
    public float minSize;
    /// <summary>
    /// Maximum size of player
    /// </summary>
    public float maxSize;



    // Player Transform reference
    private Transform ply;

    // Start is called before the first frame update
    void Start()
    {
        // Get Transform component of this object
        ply = GetComponent<Transform>();

        // Set private health to
    }

    // Update is called once per frame
    void Update()
    {
        //change s
        s += Time.deltaTime * sPerSecond;
        // Get size
        float size = s / 100 * (maxSize - minSize) + minSize;

        // Set scale based on health
        ply.transform.localScale = new(Mathf.Clamp(size, minSize, maxSize), Mathf.Clamp(size, minSize, maxSize));




    }
}
