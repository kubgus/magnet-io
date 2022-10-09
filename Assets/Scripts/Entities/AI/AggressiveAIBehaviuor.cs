using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggressiveAIBehaviuor : MonoBehaviour
{
    [SerializeField] float minRisk;
    [SerializeField] float maxRisk;
    [SerializeField] float safespace;

    [SerializeField] Transform currentTarget;

    [SerializeField] float risk;

    float moveSpeed;
    float moveDir;
    float baseDist;

    Rigidbody2D rb;
    GameObject wld;
    PlayerHealth health;

    private void Start()
    {
        risk = Random.Range(minRisk, maxRisk);

        moveSpeed = FindObjectOfType<PlayerController>().speed;

        rb = GetComponent<Rigidbody2D>();
        wld = GameObject.Find("Entities");
        health = GetComponent<PlayerHealth>();

        currentTarget = ChooseNewTarget();
    }

    private void Update()
    {
        try
        {
            baseDist = Vector2.Distance(transform.position, health.pBase.transform.position);
        }
        catch { baseDist = 0; }

        if (GetComponent<PlayerHealth>().inEnemyBase)
        {
            currentTarget = health.pBase.transform;
        }

        if (currentTarget == null)
        {
            currentTarget = ChooseNewTarget();
        }
        else
        {
            MoveTowardsTarget();
        }

        if (health.s - baseDist < risk)
        {
            currentTarget = health.pBase.transform;
        }
    }

    Transform ChooseNewTarget()
    {
        try
        {
            Transform e = wld.transform.GetChild(Random.Range(0, wld.transform.childCount));
            float d = Vector2.Distance(e.position, transform.position);
            if (d < risk)
            {
                return e;
            }
        }
        catch { }
        return null;
    }

    void MoveTowardsTarget()
    {
        rb.velocity = -0.7f * moveSpeed * (transform.position - currentTarget.position).normalized;
        if (Vector2.Distance(currentTarget.position, transform.position) < safespace)
        {
            currentTarget = ChooseNewTarget();
        }
    }
}
