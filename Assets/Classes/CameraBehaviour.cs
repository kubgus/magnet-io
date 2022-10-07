using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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
    /// <summary>
    /// Follow step
    /// </summary>
    public float step = 1f;

    // Camera reference
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        // Get Camera component of this object
        cam = GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        try
        {
            // Calculate position
            Vector2 pos = Vector2.MoveTowards(cam.transform.position, follow.transform.position, step);

            // Move towards the follow object
            cam.transform.position = new(pos.x, pos.y, distance);
        }
        catch
        {
            Debug.Log("Camera has nothing to follow.");
        }
    }
}
