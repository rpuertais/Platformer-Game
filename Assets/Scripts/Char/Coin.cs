using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int Value = 5;

    public static Action<Coin> OnCoinCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Call any method subscrived to the event
        //SendMessage("OnCoinCollected", this);
        OnCoinCollected?.Invoke(this);

        Destroy(gameObject);
    }
}
