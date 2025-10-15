using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    [Header("Setup")]
    public GameObject eggPrefab;
    public string chickenTag = "Chicken";

    [Header("Timing")]
    public float intervalSeconds = 5f;

    //[Header("Spawn Offset")]
    private float yOffset = 0.5f; // a tiny lift so it’s not inside the ground

    public float minDistanceFromChicken = 0.5f;
    public float maxDistanceFromChicken = 2.0f;


    private Transform[] chickens;

    void Start()
    {
        // Cache chickens by tag
        GameObject[] found = GameObject.FindGameObjectsWithTag(chickenTag);
        chickens = new Transform[found.Length];
        for (int i = 0; i < found.Length; i++) chickens[i] = found[i].transform;

        if (eggPrefab == null)
        {
            Debug.LogError("[SpawnManager] Assign an Egg Prefab.");
            enabled = false;
            return;
        }

        if (chickens.Length == 0)
        {
            Debug.LogWarning("[SpawnManager] No chickens found with tag: " + chickenTag);
            return;
        }

        InvokeRepeating(nameof(LayOneEgg), intervalSeconds, intervalSeconds);
    }

    void LayOneEgg()
    {
        if (eggPrefab == null || chickens == null || chickens.Length == 0) return;

        int index = Random.Range(0, chickens.Length);
        Transform chicken = chickens[index];
        if (chicken == null) return; // in case one got destroyed

        // Spawn right under the chicken (slightly above ground)
        Vector3 spawnPos = chicken.position + Vector3.up * (yOffset + 0.2f);
        GameObject egg = Instantiate(eggPrefab, spawnPos, Quaternion.identity);

        // Start a short coroutine to apply the force right after spawn
        StartCoroutine(ApplyLaunchForceNextFrame(egg, chicken));

    }

    private IEnumerator ApplyLaunchForceNextFrame(GameObject egg, Transform chicken)
    {
        // wait one fixed frame so physics can initialize
        yield return new WaitForFixedUpdate();

        if (egg == null) yield break;

        Rigidbody rb = egg.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Direction away from the chicken (slightly upward)
            Vector3 dir = (egg.transform.position - chicken.position).normalized;
            float rollForce = 3f;     // tweak strength
            float upwardForce = 0.3f; // small lift so it clears ground

            rb.AddForce(dir * rollForce + Vector3.up * upwardForce, ForceMode.Impulse);
        }

        }





        

        //Removed * yOffset
        //Vector3 pos = chicken.position + randomDir * distanceFromChicken + Vector3.up;
        //Instantiate(eggPrefab, pos, Quaternion.identity);
    }
