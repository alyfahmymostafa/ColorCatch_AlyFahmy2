using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Clips")]
    public AudioClip correctSound;
    public AudioClip incorrectSound;
    public AudioClip loseSound;

    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayCorrectSound()
    {
        if (correctSound != null) audioSource.PlayOneShot(correctSound);
    }

    public void PlayIncorrectSound()
    {
        if (incorrectSound != null) audioSource.PlayOneShot(incorrectSound);
    }

    public void PlayLoseSound()
    {
        if (loseSound != null) audioSource.PlayOneShot(loseSound);
    }
}
