using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Controller")]
    public float speed = 10f;
    public float xRange = 20f;
    public float zRange = 20f;
    public float rotationSpeed = 720f;

    private float horizontalInput;
    private float verticalInput;

    void Update()
    {
        // Get input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Movement direction
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Move the player
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

        // Rotate the player to face the movement direction
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // Keep the player inside boundaries
        float clampedX = Mathf.Clamp(transform.position.x, -xRange, xRange);
        float clampedZ = Mathf.Clamp(transform.position.z, -zRange, zRange);
        transform.position = new Vector3(clampedX, transform.position.y, clampedZ);
    }
}


