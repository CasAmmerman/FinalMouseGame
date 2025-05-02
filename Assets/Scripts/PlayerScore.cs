using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI ScoreText;

    void Start()
    {
        UpdateScoreUI();
    }
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }
    private void UpdateScoreUI()
    {
        Debug.Log("Updating Score UI. New score: " + score); 
        if (ScoreText != null)
        {
            ScoreText.text = "Score: " + score;
        }
        else
        {
            Debug.LogWarning("ScoreText is not assigned in the Inspector.");
        }
    }
}
