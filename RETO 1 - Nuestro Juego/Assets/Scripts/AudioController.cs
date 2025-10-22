using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    // Visible variables
    public AudioClip backgroundMusuc;
    public AudioClip backgroundEfects;

    // No visible variables
    private AudioSource audioSource;   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = transform.GetComponent<AudioSource>();
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
