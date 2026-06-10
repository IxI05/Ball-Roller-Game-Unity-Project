using TMPro;
using UnityEngine;

public class FinalScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI highScoreText;

    private void Start()
    {
        finalScoreText.text = "Final Score: " + ScoreManager.finalScore;
        highScoreText.text = "High Score: " + ScoreManager.highScore;
    }
}
