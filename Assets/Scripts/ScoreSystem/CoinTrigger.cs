using System;
using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    public int Value = 5;

    public static Action<CoinTrigger> OnCoinCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerAudio>().PlayCoin();
            OnCoinCollected?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
