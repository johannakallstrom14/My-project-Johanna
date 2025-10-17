using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    [Header("Setup")]
    public GameObject eggPrefab;
    public string chickenTag = "Chicken";

    [Header("Timing")]
    public float intervalSeconds = 5f;

    private float yOffset = 0.5f; // a tiny lift so it’s not inside the ground
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

        //Calls the method repeatedly every 5 seconds
        InvokeRepeating(nameof(LayOneEgg), intervalSeconds, intervalSeconds);
    }

    void LayOneEgg()
    {
        if (eggPrefab == null || chickens == null || chickens.Length == 0)
        {
            return;
        }

        //Picks random chicken from the array
        int index = Random.Range(0, chickens.Length);
        Transform chicken = chickens[index];

        //If the chicken is still missing
        if (chicken == null)
        {
            return; 
        }

        // Spawn the egg right under the chicken
        Vector3 spawnPos = chicken.position + Vector3.up * (yOffset + 0.2f);
        GameObject egg = Instantiate(eggPrefab, spawnPos, Quaternion.identity);

        // Wait one physics fram before adding force 
        StartCoroutine(ApplyLaunchForceNextFrame(egg, chicken));
    }

    private IEnumerator ApplyLaunchForceNextFrame(GameObject egg, Transform chicken)
    {
        // wait one fixed frame so physics can initialize
        yield return new WaitForFixedUpdate();

        if (egg == null)
        {
            yield break;
        }

        Rigidbody rb = egg.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Direction away from the chicken 
            Vector3 dir = (egg.transform.position - chicken.position).normalized;
            float rollForce = 3f;     
            float upwardForce = 0.3f; 

            rb.AddForce(dir * rollForce + Vector3.up * upwardForce, ForceMode.Impulse);
        }
    }
}
