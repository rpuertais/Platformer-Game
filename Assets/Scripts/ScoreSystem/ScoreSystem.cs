using System;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int Score = 0;

    public static Action<int> OnScoreUpdated;

    private void OnEnable()
    {
        CoinTrigger.OnCoinCollected += UpdateScore;
    }

    private void OnDisable()
    {
        CoinTrigger.OnCoinCollected -= UpdateScore;
    }

    private void UpdateScore(CoinTrigger coin)
    {
        Score += coin.Value;
        OnScoreUpdated?.Invoke(Score);
    }
}
