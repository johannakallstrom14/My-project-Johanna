using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    //For background music
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            //Keeps it alive between scenes
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Destroy duplicates when reloading
            Destroy(gameObject);
        }
    }
}
