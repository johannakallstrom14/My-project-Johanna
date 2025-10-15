using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int score = 0;
    public Text scoreText;

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);

        if(scoreText != null)
        {
            scoreText.text = "Score: " + score; 
        }
    }
}
