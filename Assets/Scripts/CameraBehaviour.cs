using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    /// <summary>
    /// Transform for the camera to follow
    /// </summary>
    public Transform follow;
    /// <summary>
    /// Z distance from followed object
    /// </summary>
    public float distance = -10f;

    // Camera reference
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        // Get Camera component of this object
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // Change position based on 
        try
        {
            cam.transform.position = new(follow.transform.position.x, follow.transform.position.y, distance);
        }
        catch
        {
            Debug.Log("Camera has nothing to follow.");
        }
    }
}
