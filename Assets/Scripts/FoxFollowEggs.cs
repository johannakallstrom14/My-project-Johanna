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
        //When the timer hits 0 the fox searches for a new egg
        checkTimer -= Time.deltaTime;
        if (checkTimer <= 0f)
        {
            targetEgg = FindClosestEgg();
            checkTimer = checkRate;
        }

        if (targetEgg == null)
        {
            return;
        }
           
        //Fox moves towards the egg
        Vector3 dir = targetEgg.position - transform.position;
        dir.y = 0; // stay on ground level
        float dist = dir.magnitude;

        //The fox moves if it's not too close
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

        //Searches the entire scene for all eggs, chekcs for the egg with the smallest distance
        foreach (EggCollect egg in eggs)
        {
            if (egg == null)
            {
                continue;
            }
                
            float dist = (egg.transform.position - pos).sqrMagnitude;

            //Checks for the closest egg
            if (dist < minDist)
            {
                minDist = dist;
                closest = egg.transform;
            }
        }
        return closest;
    }

}
