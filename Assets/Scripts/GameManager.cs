using UnityEngine;
using TMPro;


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

    [Header("Result UI")]
    public GameObject winPanel;
    public GameObject losePanel;

    private float timeLeft;
    private bool gameEnded = false;

    private void Start()
    {
        Time.timeScale = 1f;

        timeLeft = gameDuration;

        if (winPanel) winPanel.SetActive(false);
        if (losePanel) losePanel.SetActive(false);

        UpdateScoreUI();
        UpdateTimerUI();
    }

    void Update()
    {
        if (gameEnded) return;

        // Use deltaTime or unscaledDeltaTime
        float dt = useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;
        timeLeft -= dt;
        if (timeLeft < 0f) timeLeft = 0f;

        UpdateTimerUI();

        if (timeLeft <= 0f)
           EndGame(score >= targetScore);
        }
        
    

    public void AddScore(int amount)
    {
        if (gameEnded) return;

        score += amount;
        Debug.Log(": " + score);
        UpdateScoreUI();

        if (score >= targetScore)
            EndGame(true);
    }

    private void EndGame(bool win)
    {
        gameEnded = true;
        Time.timeScale = 0f; // pause the game

        if (win)
        {
            Debug.Log("You win!");
            if (winPanel) winPanel.SetActive(true);
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
            scoreText.text = score + " /30";
    }

    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            int seconds = Mathf.CeilToInt(timeLeft);
            timerText.text = seconds.ToString();
        }
    }

}
