using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Score Settings")]
    public int score = 0;
    public int targetScore = 30; 
    public TextMeshProUGUI scoreText;

    [Header("Timer Settings")]
    public float gameDuration = 60f; // total seconds for the round
    public TextMeshProUGUI timerText;
    public bool useUnscaledTime = false;

    [Header("UI Panels/Buttons")]
    public GameObject startPanel;
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject settingsButton;

    [Header("Pause")]
    public GameObject pausePanel;

    
    private float timeLeft;
    private bool gameEnded = false;
    private bool gameStarted = false;
    private bool isPaused = false;

    private void Start()
    {
        if (startPanel) {
            startPanel.SetActive(true);
        }

        if (winPanel) {
            winPanel.SetActive(false);
        }

        if (losePanel) {
            losePanel.SetActive(false);
        }

        if (settingsButton) {
            settingsButton.SetActive(false);
        }

        timeLeft = gameDuration;
        score = 0;
        UpdateScoreUI();
        UpdateTimerUI();

        Time.timeScale = 0f; // paused until StartGame is pressed
    }

    void Update()
    {
        if (!gameStarted || gameEnded) {
            return;
        }

        timeLeft -= Time.deltaTime;

        if (timeLeft < 0f) {
            timeLeft = 0f;
        }

     UpdateTimerUI();

        if (timeLeft <= 0f) {
            EndGame(score >= targetScore);
        }     
    }

    public void StartGame()
    {
        if (gameStarted) {
            return;
        }    
        gameStarted = true;
        gameEnded = false;

        //Reset round values
        timeLeft = gameDuration;
        score = 0;
        UpdateScoreUI();
        UpdateTimerUI();

        if (startPanel) {
            startPanel.SetActive(false);
        }

        if (winPanel) {
            winPanel.SetActive(false);
        }

        if (losePanel) {
            losePanel.SetActive(false);
        }
        
        var musicMgr = FindObjectOfType<AudioManager>();   // your DontDestroyOnLoad singleton

        if (musicMgr != null) {
            var bg = musicMgr.GetComponent<AudioSource>();
            if (bg && !bg.isPlaying) bg.Play();            // Play On Awake OFF on MusicManager
        }

        Time.timeScale = 1f; // unpause
    }

    public void AddScore(int amount)
    {
        if (!gameStarted || gameEnded) {
            return;
        }
        
        score += amount;
        Debug.Log(": " + score);
        UpdateScoreUI();

        //instant win on reaching target
        if (score >= targetScore) {
            EndGame(true);
        }  
    }

    private void EndGame(bool win)
    {
        gameEnded = true;
        Time.timeScale = 0f; // pause the game

        if (win) {
            Debug.Log("You win!");
            if (winPanel)
                winPanel.SetActive(true);
        } else {
            Debug.Log("Game over!");
            if (losePanel) losePanel.SetActive(true);
        }
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null) {
            scoreText.text = score + " /30";
        }
            
    }

    private void UpdateTimerUI()
    {
        if (timerText != null) {
            int seconds = Mathf.CeilToInt(timeLeft);
            timerText.text = seconds.ToString();
        }
    }

    public void RestartGame()
    {
        Debug.Log("[GameManager] Restarting game...");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TogglePause()
    {
        if (!gameStarted || gameEnded) {
            return;
        }

        if (isPaused) {
            ResumeGame();
        } else {
            PauseGame();
        }      
    }

    public void PauseGame()
    {
        if (isPaused) {
            return;
        }  
        isPaused = true;
        Time.timeScale = 0f;                 

        if (pausePanel) {
            pausePanel.SetActive(true);
            Debug.Log("Game Paused");
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;

        if (pausePanel) {
            pausePanel.SetActive(false);
            Debug.Log("Game Resumed");
        }      
    }
}

