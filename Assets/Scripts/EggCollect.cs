using UnityEngine;

public class EggCollect : MonoBehaviour
{
    [Header("Player Detection")]
    public string playerTag = "Player";  
    public string foxTag = "Fox";
    public float destroyDelay = 1f;      // set >0 if you want a delay before disappearing
    public int points = 0;

    [Header("Audio")]        
    public float volume = 1f;
    public AudioSource audioManager;
    public AudioClip collectSound;

    [Header("Particles")]
    public GameObject collectParticles;

    public GameManager gameManager;

    void Awake()
    {
        if (gameManager == null)
            gameManager = FindObjectOfType<GameManager>();

        if (audioManager == null)
            audioManager = FindObjectOfType<AudioManager>().GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            if (gameManager != null)
            {
                audioManager.PlayOneShot(collectSound, volume);
                gameManager.AddScore(points);

                if(collectParticles != null)
                {
                    GameObject p = Instantiate(collectParticles, transform.position, Quaternion.identity);
                    Destroy(p, 2f);
                }
            }
            Destroy(gameObject, destroyDelay);
        }

        if (other.CompareTag(foxTag))
        {
            if (gameManager != null)
                Destroy(gameObject, destroyDelay);
        }
    }
}
