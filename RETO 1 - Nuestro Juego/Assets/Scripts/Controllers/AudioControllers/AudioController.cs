using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem.XR;
using UnityEngine.Rendering;
using static Unity.VisualScripting.Member;

public class AudioController : MonoBehaviour
{
    // Visible variables
    [Header("Manager")] // Makes a header on the public variables
    public GameManager gameManager;

    [Header("Volume")] // Makes a header on the public variables
    public float generalVolume;

    [Header("Menu Clips")] // Makes a header on the public variables
    public AudioClip mainMenu;
    public AudioClip gameStart;
    public AudioClip gameOver;

    [Header("Background Clips")] // Makes a header on the public variables
    public AudioClip forestBackgroundMusic;
    public AudioClip caveBackgroundMusic;

    [Header("Player Clips")] // Makes a header on the public variables
    public AudioClip walk;
    public AudioClip run;
    public AudioClip jump;
    public AudioClip damage;

    [Header("Activation Clips")] // Makes a header on the public variables
    public AudioClip lever;
    public AudioClip elevator;
    public AudioClip elevatorEnd;
    public AudioClip movingPlatform;
    public AudioClip closingDoor;

    [Header("Object Clips")] // Makes a header on the public variables
    public AudioClip checkPoint;
    public AudioClip lifeObject;
    public AudioClip rockBreak;
    public AudioClip fallBox;

    // No visible variables
    public static AudioController Instance;
    private AudioSource mainSource;

    // START runs once before the first UPDATE it's executed
    void Start()
    {
        Debug.Log("[AudioController] .");
        mainSource = transform.GetComponent<AudioSource>();
        generalVolume = mainSource.volume;
    }

    // UPDATE is executed once per frame
    void Update()
    {

    }

    // Sets the general volume
    public void SetVolume(float volume)
    {
        generalVolume = volume;
        mainSource.volume = generalVolume;
    }

    // Instance
    public AudioController getAudioController()
    {
        return Instance;
    }

    // Menu audio control
    public void GameStartAudio()
    {
        mainSource.PlayOneShot(gameStart);
    }

    public void gameOverAudio(AudioSource source)
    {
        source.volume = generalVolume;

        mainSource.Pause();
        source.PlayOneShot(gameOver);
    }

    // Background music control
    public void backgroundAudio(string clip, bool play)
    {
        if (play)
        {
            switch (clip.ToUpper())
            {
                case "MENU":
                    mainSource.clip = mainMenu;

                    if (mainSource.clip != mainMenu)
                    {
                        mainSource.Pause();
                        mainSource.Play();
                    }
                    else
                    {
                        if (!mainSource.isPlaying)
                        {
                            mainSource.Play();
                        }
                    }
                    break;

                case "FOREST":
                    mainSource.clip = forestBackgroundMusic;

                    if (mainSource.clip != forestBackgroundMusic)
                    {
                        mainSource.Pause();
                        mainSource.Play();
                    }
                    else
                    {
                        if (!mainSource.isPlaying)
                        {
                            mainSource.Play();
                        }
                    }
                    break;

                case "CAVE":
                    mainSource.clip = caveBackgroundMusic;

                    if (mainSource.clip != caveBackgroundMusic)
                    {
                        mainSource.Pause();
                        mainSource.Play();
                    }
                    else
                    {
                        if (!mainSource.isPlaying)
                        {
                            mainSource.Play();
                        }
                    }
                    break;
            }
        }
        else
        {
            mainSource.Pause();
        }
    }

    // Player audio control
    public void playerAudio(AudioSource source, string clip, bool play)
    {
        source.volume = generalVolume;

        if (play)
        {
            switch (clip.ToUpper())
            {
                case "WALK":
                    source.volume = (source.volume * 2);
                    source.clip = walk;

                    if (source.clip != walk)
                    {
                        source.Pause();
                        source.Play();
                    }
                    else
                    {
                        if (!source.isPlaying)
                        {
                            source.Play();
                        }
                    }
                    break;

                case "RUN":
                    source.volume = (source.volume * 2);
                    source.clip = run;

                    if (source.clip != run)
                    {
                        source.Pause();
                        source.Play();
                    }
                    else
                    {
                        if (!source.isPlaying)
                        {
                            source.Play();
                        }
                    }
                    break;

                case "JUMP":
                    source.PlayOneShot(jump);
                    break;

                case "DAMAGE":
                    source.PlayOneShot(damage);
                    break;
            }
        }
        else
        {
            source.clip = null;
        }
    }

    public void playerEfects(string clip)
    {
        switch (clip.ToUpper())
        {
            case "JUMP":
                mainSource.PlayOneShot(jump);
                break;

            case "DAMAGE":
                mainSource.PlayOneShot(damage);
                break;
        }
    }

    // Lever audio control
    public void leverAudio(AudioSource source)
    {
        source.volume = generalVolume;
        source.PlayOneShot(lever);
    }

    // Elevator audio control
    public void elevatorAudio(AudioSource source, int clip, bool play)
    {
        source.volume = generalVolume;

        switch (clip)
        {
            case 1: // Elevator moving
                source.clip = elevator;

                if (play)
                {
                    if (!source.isPlaying)
                    {
                        source.Play();
                    }
                }
                else
                {
                    source.Stop();
                }
                break;

            case 2: // Elevator stops
                source.PlayOneShot(elevatorEnd);
                break;
        }
    }

    // Moving platform audio control
    public void movingPlatformAudio(AudioSource source, bool play)
    {
        source.volume = generalVolume;
        source.clip = movingPlatform;

        if (play)
        {
            if (!source.isPlaying)
            {
                source.Play();
            }
        }
        else
        {
            source.Stop(); // The audio stops
        }
    }

    // Closing door audio control
    public void closingDoorAudio(AudioSource source)
    {
        source.volume = generalVolume;
        source.PlayOneShot(closingDoor);
    }

    // Checkpoint audio control
    public void checkPointAudio(AudioSource source)
    {
        source.PlayOneShot(checkPoint);
    }

    // Life object audio control
    public void lifeObjectAudio()
    {
        mainSource.PlayOneShot(lifeObject);
    }

    // Breaking rock audio control
    public void rockBreakAudio(AudioSource source)
    {
        source.volume = (generalVolume / 5);
        source.PlayOneShot(rockBreak);
    }

    // Falling box audio control
    public void fallBoxAudio(AudioSource source)
    {
        source.volume = generalVolume;
        source.PlayOneShot(fallBox);
    }
}
