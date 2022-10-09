using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> prefabs;

    [SerializeField] float x;
    [SerializeField] float y;
    [SerializeField] int spawnDelay;
    [SerializeField] int spawnAmount;
    [SerializeField] int spawnLimit;
    [SerializeField] int despawnDistance;
    [SerializeField] string parent = "World";
 

    void Start()
    {
        Spawn();
    }

    private void Update()
    {
        // Spawn every {spawnRate} seconds
        if (Time.frameCount % spawnDelay == 0)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        Debug.Log("Spawned some Electrons");
        for (int i = 0; i < spawnAmount;i++)
        {
            GameObject world = GameObject.Find(parent);

            if (world.transform.childCount > spawnLimit)
            {
                foreach (Transform g in world.transform)
                {
                    if(Vector2.Distance(transform.position, g.transform.position) > despawnDistance)
                    {
                        Destroy(g.gameObject);
                    }
                }
            }

            GameObject e = Instantiate(prefabs[Random.Range(0,prefabs.Count)], new Vector3(Random.Range(-x, x) + transform.position.x, Random.Range(-y, y) + transform.position.y, 0), Quaternion.identity);
            e.transform.parent = world.transform;
        }
    }

}
