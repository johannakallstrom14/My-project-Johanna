using UnityEngine;

public class EggRoller : MonoBehaviour
{

    private Vector3 chickenOrigin;
    private Vector3 rollDir;
    private float stopDistance;
    private UnityEngine.Rigidbody rb;
    private bool active = false;
    private float checkDelay = 0.1f; // small delay so physics can start
    private float timer = 0f;

    public void Initialize(Vector3 chickenPosition, Vector3 direction, float distance)
    {
        chickenOrigin = chickenPosition;
        rollDir = new Vector3(direction.x, 0f, direction.z).normalized;
        stopDistance = Mathf.Max(0.1f, distance);
        rb = GetComponent<UnityEngine.Rigidbody>();
        active = true;
    }

    void FixedUpdate()
    {
        if (!active) return;

        // wait a brief moment so the impulse takes effect
        timer += Time.fixedDeltaTime;
        if (timer < checkDelay) return;

        // measure horizontal distance from the chicken
        Vector3 flatPos = new Vector3(transform.position.x, 0f, transform.position.z);
        Vector3 flatOrigin = new Vector3(chickenOrigin.x, 0f, chickenOrigin.z);
        float dist = Vector3.Distance(flatPos, flatOrigin);

        if (dist >= stopDistance)
        {
            StopEgg();
        }
    }

    private void StopEgg()
    {
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezeAll; // lock it in place
        }
        active = false;
        enabled = false;
    }
}
