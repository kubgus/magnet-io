using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ElectronBehaviour : MonoBehaviour
{
    /// <summary>
    /// Force that the object moves to the follow object
    /// </summary>
    public float force;
    /// <summary>
    /// Max distance
    /// </summary>
    public float distance;

    //
    private GameObject world;

    // Start is called before the first frame update
    void Start()
    {
        world = GameObject.Find("World");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        foreach (Transform e in world.transform)
        {
            //// Calculate position
            //Vector2 pos = Vector2.MoveTowards(e.transform.position, transform.position, Mathf.Max(0, force * (distance - Vector2.Distance(e.transform.position, transform.position))));

            //// Move towards the follow object
            //e.transform.position = new(pos.x, pos.y);

            e.GetComponent<Rigidbody2D>().velocity = (transform.position - e.position) * Mathf.Max(0, force * (distance - Vector2.Distance(e.transform.position, transform.position)));
        }
    }
}
