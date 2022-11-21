using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    // Force, apply force, 1x
    // rb.velocity = new Vector2(rb.velocity.x, jumpForce);

    [Header("None Serialized Field Vars")]
    public float jumpForce;
    public bool grounded;
    private Rigidbody2D rb;

    [Header("Serialized Field Vars")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float radOCircle;
    [SerializeField] private LayerMask whatIsGround;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, radOCircle, whatIsGround);
        // Use space and/ or w to jump
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.position, radOCircle);
    }
}
