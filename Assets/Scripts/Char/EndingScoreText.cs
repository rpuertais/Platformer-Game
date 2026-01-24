using UnityEngine;
using TMPro;

public class EndingScoreText : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        scoreText.text = "Puntuació final: " + finalScore;
    }
}
