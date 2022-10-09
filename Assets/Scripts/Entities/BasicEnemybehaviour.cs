using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyAI : MonoBehaviour
{
<<<<<<< Updated upstream
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
=======
    [SerializeField] float speed;
    Transform randomSpot;
    Rigidbody2D rb;
    public List<Transform> targets = new List<Transform>();
    [SerializeField] float minRisk;
    [SerializeField] float maxRisk;
    [SerializeField] float minAnger;
    [SerializeField] float maxAnger;
    [SerializeField] Transform eBase;

    [SerializeField] float risk;
    [SerializeField] float anger;

    bool inBase;

    bool returning;
    void Start()
    {
        randomSpot = new GameObject().transform;
        rb = GetComponent<Rigidbody2D>();
        risk = Random.Range(minRisk, maxRisk);
        anger = Random.Range(minAnger, maxAnger);
    }
    void Update()
    {
        if(eBase == null)
        {
            eBase = GetComponent<PlayerHealth>().pBase.transform;
        }
        if(returning && GetComponent<PlayerHealth>().s >= 100)
        {
            returning = false;
        }
        if (Vector2.Distance(transform.position, SelectTarget().position) < 1f)
        {
            if (SelectTarget().gameObject.CompareTag("Electron"))
            {
                targets.Remove(targets[0]);
            }
        }

        if (Vector2.Distance(transform.position, randomSpot.position) < 0.1f)
        {
            RandomSpot();
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = (SelectTarget().position - transform.position).normalized * speed;
      
    }

    public void RandomSpot()
    {
        randomSpot.position += new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), 0);
    }
    Transform SelectTarget()
    {
        for (var i = targets.Count - 1; i > -1; i--)
        {
            if (targets[i] == null)
                targets.RemoveAt(i);
        }
        if (returning)
        {
            return eBase;
        }
        if (!inBase && risk > GetComponent<PlayerHealth>().s)
        {
            returning = true;
            return eBase;
        }
        if (targets.Count > 0)
        {
            return targets[0];
        }
        return randomSpot;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Electron") && !targets.Contains(other.transform))
        {
            targets.Add(other.transform);
        }
        if (other.gameObject.CompareTag("Base") && other == GetComponent<PlayerHealth>().pBase)
        {
            inBase = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
>>>>>>> Stashed changes
    {
        
    }
}
