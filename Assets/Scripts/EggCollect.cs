using UnityEngine;

public class EggCollect : MonoBehaviour
{
    [Header("Player Detection")]
    public string playerTag = "Player";  
    public string foxTag = "Fox";
    public float destroyDelay = 1f;     
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
        {
            gameManager = FindObjectOfType<GameManager>();
        }
            
        if (audioManager == null)
        {
            audioManager = FindObjectOfType<AudioManager>().GetComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //If the player collides with an egg, play sound, add score and play particle effect
        if (other.CompareTag(playerTag)) {

            if (gameManager != null) {

                audioManager.PlayOneShot(collectSound, volume);
                gameManager.AddScore(points);

                //
                if(collectParticles != null) {

                    //Creates a spawn of the particle effect
                    GameObject p = Instantiate(collectParticles, transform.position, Quaternion.identity);
                    Destroy(p, 1f);
                }
            }
            Destroy(gameObject, destroyDelay);
        }

        //If the fox collides with an egg, destroy the egg
        if (other.CompareTag(foxTag)) {

            if (gameManager != null)
            {
                Destroy(gameObject, destroyDelay);
            }
        }
    }
}
