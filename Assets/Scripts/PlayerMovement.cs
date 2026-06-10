using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardForce = 30f;
    public float lateralForce = 15f;
    public float targetSpeed = 100f;
    public float maxLateralPos = 3f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ForwardMovement();
        LateralMovement();
    }

    void ForwardMovement()
    {
        if (rb.linearVelocity.z < targetSpeed)
        {
            rb.AddForce(Vector3.forward * forwardForce, ForceMode.Acceleration);
        }
    }

    void LateralMovement()
    {
        float direction = Input.GetAxis("Horizontal");

        Vector3 velocity = rb.linearVelocity;
        velocity.x = direction * lateralForce;
        rb.linearVelocity = velocity;

        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, -maxLateralPos, maxLateralPos);
        transform.position = position;
    }
}
