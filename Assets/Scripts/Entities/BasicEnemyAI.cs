using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemybehaviour : MonoBehaviour
{
    [SerializeField] float maxWanderRadius;
    List<Transform> targets = new List<Transform>();
    [SerializeField] Transform currentTarget;
    [SerializeField] Transform randomSpot;
    [SerializeField] float minRisk;
    [SerializeField] float maxRisk;
    [SerializeField] float minAnger;
    [SerializeField] float maxAnger;

    float risk;
    float anger;
    bool inBase;

    Rigidbody2D rb;

    private void Start()
    {
        randomSpot = new GameObject().transform;
        rb = GetComponent<Rigidbody2D>();
        risk = Random.Range(minRisk, maxRisk);
        anger = Random.Range(minAnger, maxAnger);
        ChooseNewTarget();
    }

    private void Update()
    {
        float speed = FindObjectOfType<PlayerController>().speed;
        if(currentTarget == null)
        {
            ChooseNewTarget();
        }
        rb.AddForce(currentTarget.position - transform.position * speed);
    }

    void MoveRandomSpot()
    {
        randomSpot.position = transform.position + new Vector3(Random.Range(-maxWanderRadius, maxWanderRadius), Random.Range(-maxWanderRadius, maxWanderRadius),0);
    }

    void ChooseNewTarget()
    {
        if (targets.Count <= 0)
        {
            targets.Add(randomSpot);
            MoveRandomSpot();
        }
        currentTarget = targets[0];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Electron"))
        {
            targets.Add(other.transform);
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform == currentTarget)
        {
            currentTarget = transform;
            targets.Remove(other.transform);
            Invoke("ChooseNewTarget", Random.Range(0.1f, 2.5f));
        }
    }
}
