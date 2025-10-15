using UnityEngine;

public class PauseManager : MonoBehaviour
{

    private bool isPaused = false;
    public GameObject pausePanel;

    // Update is called once per frame
    void Update()
    {
        // Press Escape to toggle pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;   // Pause game
            Debug.Log("Game Paused");
            pausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;   // Resume game
            Debug.Log("Game Resumed");
            pausePanel.SetActive(false);
        }
    }
}
