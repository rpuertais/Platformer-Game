using System;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float jumpValue;
    public static Action<PowerUp> OnPowerCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnPowerCollected?.Invoke(this);
        Destroy(gameObject);
    }
}
