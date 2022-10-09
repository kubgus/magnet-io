using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BasicEnemyAI : MonoBehaviour
{
    [SerializeField] float minRisk;
    [SerializeField] float maxRisk;
    [SerializeField] float safespace = 5f;

    [SerializeField] Transform currentTarget;

    float risk;

    float moveSpeed;
    float moveDir;

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
        if (currentTarget == null)
        {
            currentTarget = ChooseNewTarget();
            MoveRandomSpot();
        }
        else
        {
            MoveTowardsTarget();
        }

        if (health.s < risk || Random.Range(0, risk) == 0)
        {
            currentTarget = health.pBase.transform;
        }
    }

    Transform ChooseNewTarget()
    {
        foreach (Transform e in wld.transform.GetChild(Random.Range(0,wld.transform.childCount)))
        {
            if (Vector2.Distance(e.position, transform.position) > safespace * 1.5f) {
                return e;
            }
        }
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
