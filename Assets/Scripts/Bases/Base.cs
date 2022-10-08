using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    float level;
    [SerializeField] float startSize = 5;
    [SerializeField] float smoothPerSecond;
    [SerializeField] float electronBonus;

    float level;

    private void Start()
    {
        level = 5;
    }

    private void Update()
    {
        health.baseSize = level;
        float trueScale = Mathf.Lerp(transform.localScale.x, level * startSize, Time.deltaTime * smoothPerSecond);
        float trueScale = Mathf.Lerp(transform.localScale.x, level * 3, Time.deltaTime * smoothPerSecond);
        transform.localScale = new Vector2(trueScale, trueScale);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Electron"))
        {
            Destroy(other.gameObject);
            level += 0.02f;
            level += electronBonus;
        }
    }
}