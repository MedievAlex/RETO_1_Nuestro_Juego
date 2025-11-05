using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem.XR;
using UnityEngine.Rendering;

public class AudioController : MonoBehaviour
{
    // Visible variables
    [Header("Background Clips")] // Makes a header on the public variables
    public AudioClip backgroundMusic;
    public AudioClip backgroundEfects;

    // No visible variables
    public static AudioController Instance;
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

    // Sets the general volume
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    // Instance
    public AudioController getAudioController()
    {
        return Instance;
    }

    // Background music
    public void playBackgroundMusic(AudioClip audioClip, float volume, bool play)
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

    // Audio that needs to be playing while its true
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



    // Methods to play the audios
    public void onLoopAudio(AudioClip audioClip, float volume, bool play)
    {
        audioSource.clip = audioClip;

        if (!play)
        {
            audioSource.PlayOneShot(audioClip, volume); // The audio plays
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
