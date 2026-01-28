using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioClip JumpSound;
    public AudioClip CoinSound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayJump()
    {
        audioSource.PlayOneShot(JumpSound);
    }

    public void PlayCoin()
    {
        audioSource.PlayOneShot(CoinSound);
    }
}


