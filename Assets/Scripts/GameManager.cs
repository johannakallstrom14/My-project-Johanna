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

    [Header("UI Panels")]
    public GameObject startPanel;
    public GameObject winPanel;
    public GameObject losePanel;

<<<<<<< HEAD
    [Header("Pause")]
    public GameObject pausePanel;
    
=======
>>>>>>> parent of c682398 (Particle System coins & pause button)
    private float timeLeft;
    private bool gameEnded = false;
    private bool gameStarted = false;

    private void Start()
<<<<<<< HEAD
    {
        //Load StartScene
        startPanel.SetActive(true);
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        settingsButton.SetActive(false);
=======
    { 
        if (startPanel) startPanel.SetActive(true);
        if (winPanel) winPanel.SetActive(false);
        if (losePanel) losePanel.SetActive(false);
>>>>>>> parent of c682398 (Particle System coins & pause button)

        timeLeft = gameDuration;
        score = 0;
        UpdateScoreUI();
        UpdateTimerUI();

        //paused until StartGame is pressed
        Time.timeScale = 0f; 
    }

    void Update()
    {
<<<<<<< HEAD
        if (!gameStarted || gameEnded)
        {
            return;
        }
=======
        if (!gameStarted || gameEnded) return;
>>>>>>> parent of c682398 (Particle System coins & pause button)

        //Countdown for the timer
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0f) timeLeft = 0f;

<<<<<<< HEAD
        //Prevents timer to count negative numbers
        if (timeLeft < 0f)
        {
            timeLeft = 0f;
        }

        
     UpdateTimerUI();

        //End game when time is up
        if (timeLeft <= 0f)
        {
=======
        UpdateTimerUI();

        if (timeLeft <= 0f)
>>>>>>> parent of c682398 (Particle System coins & pause button)
            EndGame(score >= targetScore);
    }

    public void StartGame()
    {
<<<<<<< HEAD
        if (gameStarted)
        {
            return;
        }

=======
        if (gameStarted) return;
>>>>>>> parent of c682398 (Particle System coins & pause button)
        gameStarted = true;
        gameEnded = false;

        //Reset round values
        timeLeft = gameDuration;
        score = 0;
        UpdateScoreUI();
        UpdateTimerUI();

<<<<<<< HEAD
        startPanel.SetActive(false);
        winPanel.SetActive(false);
        losePanel.SetActive(false);

        //Starts the background music
        AudioManager audioMgr = FindObjectOfType<AudioManager>();   
        if (audioMgr != null)
        {
            AudioSource bg = audioMgr.GetComponent<AudioSource>();
            if (bg && !bg.isPlaying) bg.Play();            
        }

        // unpause game
        Time.timeScale = 1f; 
=======
        if (startPanel) startPanel.SetActive(false);
        if (winPanel) winPanel.SetActive(false);
        if (losePanel) losePanel.SetActive(false);

        var musicMgr = FindObjectOfType<AudioManager>();   // your DontDestroyOnLoad singleton
        if (musicMgr != null)
        {
            var bg = musicMgr.GetComponent<AudioSource>();
            if (bg && !bg.isPlaying) bg.Play();            // Play On Awake OFF on MusicManager
        }

        Time.timeScale = 1f; // unpause
>>>>>>> parent of c682398 (Particle System coins & pause button)
    }

    public void AddScore(int amount)
    {
<<<<<<< HEAD
        if (!gameStarted || gameEnded)
        {
            return;
        }
        
=======
        if (!gameStarted || gameEnded) return;

>>>>>>> parent of c682398 (Particle System coins & pause button)
        score += amount;
        Debug.Log(": " + score);
        UpdateScoreUI();

        //instant win on reaching target
        if (score >= targetScore)
<<<<<<< HEAD
        {
=======
>>>>>>> parent of c682398 (Particle System coins & pause button)
            EndGame(true);
    }

    private void EndGame(bool win)
    {
        gameEnded = true;
        Time.timeScale = 0f; // pause the game

        if (win)
        {
            Debug.Log("You win!");
<<<<<<< HEAD
            if (winPanel)
                winPanel.SetActive(true);
=======
            if (winPanel) winPanel.SetActive(true);
>>>>>>> parent of c682398 (Particle System coins & pause button)
        }
        else
        {
            Debug.Log("Game over!");
            if (losePanel) losePanel.SetActive(true);
        }
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
<<<<<<< HEAD
        {
            scoreText.text = score + " /30";
        }  
=======
            scoreText.text = score + " /30";
>>>>>>> parent of c682398 (Particle System coins & pause button)
    }

    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
<<<<<<< HEAD
            //Rounds up to the nearest whole numer, convert timer to int
=======
>>>>>>> parent of c682398 (Particle System coins & pause button)
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

<<<<<<< HEAD
    //Pause button
    public void TogglePause()
    {
        if (!gameStarted || gameEnded)
        {
            return;
        }

        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }      
    }

    public void PauseGame()
    {
        if (isPaused)
        {
            return;
        }  
        isPaused = true;
        Time.timeScale = 0f;                 

        if (pausePanel)
        {
            pausePanel.SetActive(true);
            Debug.Log("Game Paused");
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;

        if (pausePanel)
        {
            pausePanel.SetActive(false);
            Debug.Log("Game Resumed");
        }      
    }
=======
>>>>>>> parent of c682398 (Particle System coins & pause button)
}
