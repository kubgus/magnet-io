using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BasicAIBehaviour : MonoBehaviour
{

    [SerializeField] float minRisk;
    [SerializeField] float maxRisk;
    [SerializeField] float safespace = 5f;

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
        wld = GameObject.Find("World");
        health = GetComponent<PlayerHealth>();

        currentTarget = ChooseNewTarget();
    }

    private void Update()
    {
        baseDist = Vector2.Distance(transform.position, health.pBase.transform.position);

        if (GetComponent<PlayerHealth>().inEnemyBase)
        {
            currentTarget = null;
            moveDir -= 3.14f;
        }

        if (currentTarget == null)
        {
            currentTarget = ChooseNewTarget();
            MoveRandomSpot();
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
            if (d > safespace || d < risk)
            {
                return e;
            }
        } catch { }
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

    void MoveRandomSpot()
    {
        if (Random.Range(0,400) == 0)
        {
            moveDir = Random.Range(0f, 6.28f);
        }
        Vector2 v;
        v.x = Mathf.Cos(moveDir);
        v.y = Mathf.Sin(moveDir);
        rb.velocity = 0.9f * moveSpeed * v.normalized;
    }
}
