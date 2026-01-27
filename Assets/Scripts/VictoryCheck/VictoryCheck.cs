using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryCheck : MonoBehaviour
{
    public ScoreSystem ScoreSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("FinalScore", ScoreSystem.Score);
            PlayerPrefs.Save();
            SceneManager.LoadScene(2);
        }
    }
}
