using UnityEngine;

public class CamFollower : MonoBehaviour
{
    public Transform CamFollow;

    public float Speed;

    private float startTime;
    private float dist;
    private float z;

    void Start()
    {
        startTime = Time.time;
        dist = Vector3.Distance(transform.position, CamFollow.position);
        z = transform.position.z;
    }

    void Update()
    {
        float distCovered = (Time.time - startTime) * Speed;
        float fractionOfJourney = distCovered / dist;
        Vector3 newPosition = Vector3.Lerp(transform.position, CamFollow.position, fractionOfJourney);
        newPosition.z = z;
        transform.position = newPosition;
    }
}
