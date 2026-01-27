using UnityEngine;
using TMPro;

public class EndingScoreText : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;

    void Start()
    {
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        ScoreText.text = "Final Score: " + finalScore;
    }
}
