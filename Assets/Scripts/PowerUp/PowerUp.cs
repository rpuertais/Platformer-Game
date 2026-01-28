using System;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float JumpValue;

    public static Action<PowerUp> OnPowerCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnPowerCollected?.Invoke(this);
        Destroy(gameObject);
    }
}
