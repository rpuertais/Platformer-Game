using UnityEngine;

public class CamFollower : MonoBehaviour
{
    public Transform camFollower;
    public float speed;
    private float startTime;
    private float dist;

    private float z;
    void Start()
    {
        startTime = Time.time;

        dist = Vector3.Distance(transform.position, camFollower.position);

        z = transform.position.z;
    }
    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;

        float fractionOfJourney = distCovered / dist;
        Vector3 newPosition = Vector3.Lerp(transform.position, camFollower.position, fractionOfJourney);
        newPosition.z = z;

        transform.position = newPosition;
    }
}
