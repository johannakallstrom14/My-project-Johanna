using UnityEngine;

public class EggCollect : MonoBehaviour
{
    [Header("Player Detection")]
    public string playerTag = "Player";  // tag your player with "Player"
    public float destroyDelay = 0f;      // set >0 if you want a delay before disappearing
    public int points = 0;

    public GameManager gameManager;

    void Awake()
    {
        if (gameManager == null)
            gameManager = FindObjectOfType<GameManager>();

        if (gameManager == null)
            Debug.LogError("EggCollect: No GameManager found in the scene.");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            if (gameManager != null)
                gameManager.AddScore(points);

            Destroy(gameObject, destroyDelay);
        }
    }
}
