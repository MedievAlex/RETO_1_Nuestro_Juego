using UnityEngine;

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
    private AudioSource mainSource;

    // START runs once before the first UPDATE it's executed
    void Start()
    {
        Debug.Log("[AudioController] Getting Started.");
        mainSource = transform.GetComponent<AudioSource>();
        generalVolume = mainSource.volume;
    }

    // Sets the general volume
    public void SetVolume(float volume)
    {
        Debug.Log("[AudioController]Volume Set.");
        generalVolume = volume;
        mainSource.volume = generalVolume;
    }

    // ---------------------------------------------------------------------------[ Menu ]------------------------------------------------------------------------------------

    // Menu audio control
    public void GameStartAudio()
    {
        Debug.Log("[AudioController] Game Start.");
        mainSource.PlayOneShot(gameStart);
    }

    public void GameOverAudio()
    {
        Debug.Log("[AudioController] Game Over.");
        mainSource.Pause();
        mainSource.PlayOneShot(gameOver);
    }

    // ---------------------------------------------------------------------------[ Background ]------------------------------------------------------------------------------

    // Background music control
    public void BackgroundAudio(string clip, bool play)
    {
        if (play)
        {
            switch (clip.ToUpper())
            {
                case "MENU":
                    Debug.Log("[AudioController] Now Playing: Main Menu.");
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
                    Debug.Log("[AudioController] Now Playing: Forest.");
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
                    Debug.Log("[AudioController] Now Playing: Cave.");
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

    // ---------------------------------------------------------------------------[ Player ]----------------------------------------------------------------------------------

    // Player audio control
    public void PlayerAudio(AudioSource source, string clip, bool play)
    {
        source.volume = generalVolume;

        if (play)
        {
            switch (clip.ToUpper())
            {
                case "WALK":
                    Debug.Log("[AudioController] Player: Walking.");
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
                    Debug.Log("[AudioController] Player: Running.");
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
                    Debug.Log("[AudioController] Player: Jump.");
                    source.PlayOneShot(jump);
                    break;

                case "DAMAGE":
                    Debug.Log("[AudioController] Player: Damage.");
                    source.PlayOneShot(damage);
                    break;
            }
        }
        else
        {
            source.clip = null;
        }
    }

    public void PlayerEffects(string clip)
    {
        switch (clip.ToUpper())
        {
            case "JUMP":
                Debug.Log("[AudioController] Player: Jump.");
                mainSource.PlayOneShot(jump);
                break;

            case "DAMAGE":
                Debug.Log("[AudioController] Player: Damage.");
                mainSource.PlayOneShot(damage);
                break;
        }
    }

    // ---------------------------------------------------------------------------[ Activation ]------------------------------------------------------------------------------

    // Lever audio control
    public void LeverAudio(AudioSource source)
    {
        Debug.Log("[AudioController] Lever Audio.");
        source.volume = generalVolume;
        source.PlayOneShot(lever);
    }

    // Elevator audio control
    public void ElevatorAudio(AudioSource source, int clip, bool play)
    {
        source.volume = generalVolume;

        switch (clip)
        {
            case 1: // Elevator moving
                Debug.Log("[AudioController] Elevator: Moving.");
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
                Debug.Log("[AudioController] Elevator: Stop.");
                source.PlayOneShot(elevatorEnd);
                break;
        }
    }

    // Moving platform audio control
    public void MovingPlatformAudio(AudioSource source, bool play)
    {
        Debug.Log("[AudioController] Moving Platform.");
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
    public void ClosingDoorAudio(AudioSource source)
    {
        Debug.Log("[AudioController] Closing Door.");
        source.volume = generalVolume;
        source.PlayOneShot(closingDoor);
    }

    // ---------------------------------------------------------------------------[ Objects ]-------------------------------------------------------------------------------

    // Checkpoint audio control
    public void CheckPointAudio(AudioSource source)
    {
        Debug.Log("[AudioController] Checkpoint.");
        source.PlayOneShot(checkPoint);
    }

    // Life object audio control
    public void LifeObjectAudio()
    {
        Debug.Log("[AudioController] Life Object.");
        mainSource.PlayOneShot(lifeObject);
    }

    // Breaking rock audio control
    public void RockBreakAudio(AudioSource source)
    {
        Debug.Log("[AudioController] Rock Break.");
        source.volume = (generalVolume / 5);
        source.PlayOneShot(rockBreak);
    }

    // Falling box audio control
    public void FallBoxAudio(AudioSource source)
    {
        Debug.Log("[AudioController] Fall Box.");
        source.volume = generalVolume;
        source.PlayOneShot(fallBox);
    }
}
