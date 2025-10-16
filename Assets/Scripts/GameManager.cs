using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{

    public int score = 0;
    public TextMeshProUGUI scoreText;

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log(": " + score);

        if(scoreText != null)
        {
            scoreText.text = ": " + score; 
        }
    }
}
