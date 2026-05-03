using UnityEngine;

public class SoundController : MonoBehaviour
{

    public static SoundController Instance { get; private set; }

    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip birdDie;
    [SerializeField] private AudioClip pipeCollision;
    [SerializeField] private AudioClip gotScore;
    [SerializeField] private AudioClip wingFlap;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void BirdDies()
    {
        audioSource.PlayOneShot(birdDie);
    }

    public void BirdCollidesWithPipe()
    {
        audioSource.PlayOneShot(pipeCollision);
    }

    public void BirdGetsScore()
    {
        audioSource.PlayOneShot(gotScore);
    }

    public void BirdFlapsWing()
    {
        audioSource.PlayOneShot(wingFlap);
    }
}
