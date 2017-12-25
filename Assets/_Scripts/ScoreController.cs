using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public static int score = 0;
    private Text scoreText;

    private void Start()
    {
        scoreText = GetComponent<Text>();
        ResetScore();
    }

    public void AddScore(int points)
    {
        score += points;
        SetText();
    }

    public static void ResetScore()
    {
        score = 0;
    }

    private void SetText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
