using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    BasicEnemyBehaviour b;
    [SerializeField] bool detectBase;

    private void Start()
    {
        b = GetComponentInParent<BasicEnemyBehaviour>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Electron") && !b.targets.Contains(collision.transform) && !detectBase)
        {
            b.targets.Add(collision.transform);
        }
        if (collision.gameObject.CompareTag("Base") && collision != b.GetComponent<PlayerHealth>().pBase && detectBase)
        {
            b.RandomSpot();
        }
    }
}
