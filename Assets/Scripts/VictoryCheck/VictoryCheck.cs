using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryCheck : MonoBehaviour
{
    public ScoreSystem scoreSystem;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("FinalScore", scoreSystem.Score);
            PlayerPrefs.Save();
            SceneManager.LoadScene(2);
        }
    }
}
