using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> prefabs;

    [SerializeField] float x;
    [SerializeField] float y;
    [SerializeField] int spawnRate;
    [SerializeField] int spawnAmount;
    [SerializeField] int spawnLimit;


    void Start()
    {
        Spawn();
    }

    private void Update()
    {
        // Spawn every {spawnRate} seconds
        if (Time.frameCount % spawnRate == 0)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        Debug.Log("Spawned some Electrons");
        for (int i = 0; i < spawnAmount;)
        {
            GameObject world = GameObject.Find("World");

            if (world.transform.childCount > spawnLimit)
            {
                foreach (Transform g in world.transform)
                {
                    if(!g.GetComponent<Renderer>().isVisible)
                    {
                        Destroy(g.gameObject);
                    }
                }
            }

            GameObject e = Instantiate(prefabs[Random.Range(0,prefabs.Count)], new Vector3(Random.Range(-x, x) + transform.position.x, Random.Range(-y, y) + transform.position.y, 0), Quaternion.identity);
            // Make sure it spawns outside of view
            if (e.GetComponent<Renderer>().isVisible)
            {
                Destroy(e);
                return;
            }
            e.transform.parent = world.transform;
            i++;
        }
    }

}
