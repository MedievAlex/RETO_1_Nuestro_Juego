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

    [Header("Player Clips")] // Makes a header on the public variables
    public AudioClip walk;
    public AudioClip run;
    public AudioClip jump;
    public AudioClip damage;

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

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void abilityAudio(string abilityName, bool play)
    {
        switch (abilityName.ToUpper())
        {
            case "WALK":
                if (play)
                {
                    audioSource.PlayOneShot(walk); 
                }
                else
                {
                    audioSource.Stop(); 
                }
                break;
            case "DASH":
                if (play)
                {
                    audioSource.PlayOneShot(run); 
                }
                else
                {
                    audioSource.Stop(); 
                }
                break;
            case "JUMP":
                if (play)
                {
                    audioSource.PlayOneShot(jump);
                }
                else
                {
                    audioSource.Stop(); 
                }
                break;
            case "DAMAGE":
                if (play)
                {
                    audioSource.PlayOneShot(damage);
                }
                else
                {
                    audioSource.Stop(); 
                }
                break;
        }
    }

    // Methods to plat the audios
    public void onLoopAudio(AudioClip audioClip, float volume, bool play)
    {
        audioSource.clip = audioClip;

        if (!play)
        {
            audioSource.PlayOneShot(audioClip, volume); // The audio plays
        }
    }

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

    public AudioController getAudioController()
    {
        return Instance;
    }
}
