using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Acceleration of the Rigidbody2D
    /// </summary>
    public float speed;

    // Rigidbody2D reference
    private Rigidbody2D rb;
    // Velocity carrier variable
    private Vector2 v;

    // Start is called before the first frame update
    void Start()
    {
        // Get Rigidbody2D component of this object
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Change velocity carrier variable based on speed and input
        Vector2 input = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        v = speed * input.normalized;
    }

    private void FixedUpdate()
    {
        // Change object's position
        rb.velocity = v;
    }
}
