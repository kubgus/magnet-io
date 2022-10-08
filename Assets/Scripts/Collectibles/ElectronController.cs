using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ElectronController : MonoBehaviour
{

    /// <summary>
    /// Force that the object moves to the follow object
    /// </summary>
    public float force;
    /// <summary>
    /// Max distance
    /// </summary>
    public float distance;
    /// <summary>
    /// Adds a bit of randomness
    /// </summary>
    public float instability;

    //
    private GameObject ent;
    //
    private GameObject wld;

    // Start is called before the first frame update
    void Start()
    {
        ent = GameObject.Find("Entities");
        wld = GameObject.Find("World");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        foreach (Transform e in ent.transform)
        {
            // Calculated distance between electron and object
            float _distance = Vector2.Distance(transform.position, e.transform.position);

            //// Calculate position
            //Vector2 pos = Vector2.MoveTowards(e.transform.position, transform.position, Mathf.Max(0, force * (distance - Vector2.Distance(e.transform.position, transform.position))));

            //// Move towards the follow object
            //e.transform.position = new(pos.x, pos.y);

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            Vector2 f = (e.position - transform.position) * Mathf.Max(0, force * (distance - _distance));
            if (Random.Range(0,instability) == 0)
            {
                rb.AddForce(f);
            }
        }
    }
}
