using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI TxtScore;
    public int score = 0;
    public int distanceMultiplier = 1;

    private Transform player;

    public static int finalScore = 0;
    public static int highScore = 0;

    private const string HIGH_SCORE_KEY = "HighScore";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Load high score at start
        highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
    }

    private void Update()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        score = Mathf.FloorToInt(player.position.z * distanceMultiplier);
        TxtScore.text = score.ToString();
    }

    public void SaveFinalScore()
    {
        finalScore = score;

        // Update high score
        if (finalScore > highScore)
        {
            highScore = finalScore;
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, highScore);
            PlayerPrefs.Save();
        }
    }
}
