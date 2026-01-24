using UnityEngine;

public class PlayerAudio : MonoBehaviour
{

    public AudioClip jumpSound;
    public AudioClip coinSound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayJump()
    {
        audioSource.PlayOneShot(jumpSound);
    }

    public void PlayCoin()
    {
        audioSource.PlayOneShot(coinSound);
    }
}


