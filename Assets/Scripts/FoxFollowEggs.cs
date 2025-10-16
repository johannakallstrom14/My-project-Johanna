using UnityEngine;

public class FoxFollowEggs : MonoBehaviour
{

[Header("Targeting")]
    public float speed = 3f;
    public float stopDistance = 0.5f;
    public float checkRate = 0.5f;
    public float smoothTurn = 4f;

    private Transform targetEgg;
    private float checkTimer;

    void Update()
    {
        checkTimer -= Time.deltaTime;
        if (checkTimer <= 0f)
        {
            targetEgg = FindClosestEgg();
            checkTimer = checkRate;
        }

        if (targetEgg == null) return;

        // Move toward the egg
        Vector3 dir = targetEgg.position - transform.position;
        dir.y = 0; // stay on ground level
        float dist = dir.magnitude;

        if (dist > stopDistance)
        {
            transform.position += dir.normalized * speed * Time.deltaTime;

            // Smoothly rotate toward the target direction
            transform.forward = Vector3.Slerp(transform.forward, dir.normalized, Time.deltaTime * smoothTurn);
        }
    }

    Transform FindClosestEgg()
    {
        // Find all eggs that have the EggCollect component instead of using a tag
        EggCollect[] eggs = FindObjectsOfType<EggCollect>();

        Transform closest = null;
        float minDist = Mathf.Infinity;
        Vector3 pos = transform.position;

        foreach (EggCollect egg in eggs)
        {
            if (egg == null) continue;
            float dist = (egg.transform.position - pos).sqrMagnitude;
            if (dist < minDist)
            {
                minDist = dist;
                closest = egg.transform;
            }
        }
        return closest;
    }

}
