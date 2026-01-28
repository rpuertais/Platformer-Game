using UnityEngine;
using UnityEngine.Events;

public class GroundChecker : MonoBehaviour
{
    public UnityEvent GroundHitEvent;
    public UnityEvent GroundNoHitEvent;

    public string[] CollidableTags;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (TagCompare(collision))
        {
            GroundHitEvent?.Invoke();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (TagCompare(collision))
        {
            GroundHitEvent?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (TagCompare(collision))
        {
            GroundNoHitEvent?.Invoke();
        }
    }

    private bool TagCompare(Collider2D collision)
    {
        foreach (string tag in CollidableTags)
        {
            if (collision.CompareTag(tag))
            {
                return true;
            }
        }
        return false;
    }
}
