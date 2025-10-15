using UnityEngine;

public class EggCollect : MonoBehaviour
{
    [Header("Player Detection")]
    public string playerTag = "Player";  // tag your player with "Player"
    public float destroyDelay = 0f;      // set >0 if you want a delay before disappearing

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            // Optional: play a sound or animation before destroying
            Destroy(gameObject, destroyDelay);
        }
    }
}
