using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    // Visible variables
    public AudioClip backgroundMusic;
    public AudioClip backgroundEfects;

    // No visible variables
    private static AudioController Instance;
    private AudioSource audioSource;   

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource = transform.GetComponent<AudioSource>();
            
            audioSource.volume = 0.5f;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource.clip = backgroundMusic;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onLoopAudio(AudioClip audioClip, float volume, bool play)
    {
        audioSource.clip = audioClip;

        if (!play)
        {
            audioSource.PlayOneShot(audioClip, volume); // The audio plays
        }
    }
    
    public void backgroundMusic(AudioClip audioClip, float volume, bool play)
    {
        audioSource.clip = audioClip;

        if (play)
        {
            audioSource.PlayOneShot(audioClip, volume); // The audio plays
        }
        else
        {
            audioSource.Stop(); // The audio stops
        }
    }

    public void verifyedOShotAudio(AudioClip audioClip, float volume, bool play)
    {
        if (play)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(audioClip, volume); // The audio plays
            }
        }
        else
        {
            audioSource.Stop(); // The audio stops
        }
    }

    public void oneShotAudio(AudioClip audioClip, float volume, bool play)
    {

        if (play)
        {
            audioSource.PlayOneShot(audioClip, volume); // The audio plays
        }
        else
        {
            audioSource.Stop(); // The audio stops
        }
    }
}
