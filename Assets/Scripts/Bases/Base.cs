using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public Transform owner;

    [SerializeField] float startSize = 5f;
    [SerializeField] float smoothPerSecond;
    [SerializeField] float electronBonus;

    float level;

    private void Start()
    {
        level = 0;
    }

    private void Update()
    {
        if (owner == null)
        {
            Destroy(gameObject);
        }

        float trueScale = Mathf.Lerp(transform.localScale.x, level + startSize, Time.deltaTime * smoothPerSecond);
        transform.localScale = new Vector2(trueScale, trueScale);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Electron") && other.GetType() == typeof(CircleCollider2D))
        {
            Destroy(other.gameObject);
            level += electronBonus;
        }
    }
}