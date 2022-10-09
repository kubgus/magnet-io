using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Acceleration of the Rigidbody2D
    /// </summary>
    public float speed;
    [SerializeField] float safeSpace;
    // Rigidbody2D reference
    private Rigidbody2D rb;
    // Velocity carrier variable
    private Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        // Get Rigidbody2D component of this object
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos.z = 10;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void FixedUpdate()
    {
        // Change object's position
        if (safeSpace < Vector2.Distance(transform.position, mousePos))
        {
            rb.velocity = (mousePos - transform.position).normalized * speed;
        }
    }
}


