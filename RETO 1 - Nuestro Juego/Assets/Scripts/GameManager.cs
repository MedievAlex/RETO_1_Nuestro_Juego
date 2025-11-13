using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Visible variables
    [Header("Player")] // Makes a header on the public variables
    public Player2D player;

    [Header("Controllers")] // Makes a header on the public variables
    public MenuController menuController;
    public LevelController levelController;
    public UIController uiController;
    public AudioController audioController;

    // Not visible variables
    private static GameManager Instance;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("[GAME MANAGER] Start Settings.");
        StartSettings();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Sets the values before starting the game
    private void StartSettings()
    {
        Debug.Log("[GAME MANAGER] Starting Levels.");
        levelController.StartSettings();
        Debug.Log("[GAME MANAGER] Starting Menus.");
        menuController.StartSettings();
        Debug.Log("[GAME MANAGER] Starting UI.");
        uiController.StartSettings();
    }

    // Closes the Game
    public void CloseGame()
    {
        Application.Quit();
    }

    // ---------------------------------------------------------------------------[ Menu ]------------------------------------------------------------------------------------

    // Opens Main Menu
    public void OpenMainMenu(bool active)
    {
        Debug.Log("[GAME MANAGER] Open Main Menu " + active + ".");
        ActivateUI(false);
        levelController.MainMenu();
    }

    // Opens Options Menu
    public void OpenOptionsMenu(bool active)
    {
        Debug.Log("[GAME MANAGER] Open Options Menu " + active + ".");
        menuController.OpenOptionsMenu(active);
    }

    // Sets the background for each level
    public void SetSpecificBackground(int level)
    {
        if (level > 0)
        {
            Debug.Log("[GAME MANAGER] Setting specific Background for Level-" + level + ".");
        }
        else
        {
            Debug.Log("[GAME MANAGER] Setting specific Background for Main Menu.");
        }
        menuController.SetSpecificBackground(level);
    }

    // Opens Game Over Menu
    public void OpenGameOverMenu(bool active)
    {
        Debug.Log("[GAME MANAGER] Open Options Menu " + active + ".");
        ActivateUI(!active);
        levelController.MainMenu();
        menuController.OpenGameOverMenu(active);
    }

    // ---------------------------------------------------------------------------[ Level ]------------------------------------------------------------------------------------
    
    // Loads the fist level
    public void GameStart()
    {
        Debug.Log("[GAME MANAGER] Starting Game.");
        audioController.GameStartAudio();
        levelController.GameStart();
        ActivateUI(true);
        ResetTimer();
        PauseTimer(false);
        menuController.SetPauseActivable(true);
    }

    // Loads the next level
    public void NextLevel()
    {
        Debug.Log("[GAME MANAGER] Next Level.");
        levelController.NextLevel();
    }

    // Restart the Game and Timer
    public void RestartGame()
    {
        Debug.Log("[GAME MANAGER] Restarting Game.");
        levelController.RestartGame();
        ActivateUI(true);
        menuController.SetPauseActivable(true);
        ResetTimer();
        PauseTimer(false);
    }

    // Gets the number of the level
    public int GetLevel()
    {
        int level = levelController.GetLevel();
        Debug.Log("[GAME MANAGER] Actual Level: " + level + ".");
        return level;
    }

    // ---------------------------------------------------------------------------[ Player ]-----------------------------------------------------------------------------------

    // Sets the current player
    public void SetPlayer(Player2D player)
    {
        Debug.Log("[GAME MANAGER] Setting Player.");
        this.player = player;
    }

    // Deals damage
    public void ApplyDamage()
    {
        player.ApplyDamage();
    }

    // Feezes or unfeezes the player
    public bool FrozenState()
    {
        return player.FrozenState();
    }

    // Feezes or unfeezes the player
    public void Freeze(bool frozen)
    {
        player.Freeze(frozen);
    }

    // Sets respawn
    public void SetRespawn(Vector3 newSpawnPoint)
    {
        player.SetRespawn(newSpawnPoint);
    }

    // Gets the actual respawn point
    public Vector3 GetRespawn()
    {
        return player.GetRespawn();
    }

    // Respawns in the registered spawnpoint
    public void Respawn()
    {
        player.Respawn();
    }

    // Ability gestion
    public void AbilityGestion(string abilityName, bool active)
    {
        player.AbilityGestion(abilityName, active);
    }

    // ---------------------------------------------------------------------------[ UI ]---------------------------------------------------------------------------------------

    // Activates or deactivates the UI
    public void ActivateUI(bool active)
    {
        Debug.Log("[GAME MANAGER] Active UI " + active + ".");
        uiController.SetActive(active);
    }

    // Activates or deactivates the UI
    public void DamageBorder(bool active)
    {
        Debug.Log("[GAME MANAGER] Damage Border " + active + ".");
        uiController.SetActive(active);
    }

    // Shows or hides the Damage Border
    public void ShowDamageBorder(bool visible, float visibleSeconds)
    {
        Debug.Log("[GAME MANAGER] Damage Border visible " + visible + ".");
        uiController.ShowDamageBorder(visible, visibleSeconds);
    }

    // Plays Timer audio
    public void CountdownAudio(AudioSource audioSource)
    {
        audioController.CountdownAudio(audioSource);
    }

    // ---------------------------------------------------------------------------[ UI: Health Bar ]---------------------------------------------------------------------------

    // Updates life
    public void UpdateLives(int lives)
    {
        Debug.Log("[GAME MANAGER] Update Lives.");
        uiController.UpdateLives(lives);
    }

    // Gets the heart count
    public int GetLives()
    {
        int lives = uiController.GetLives();
        Debug.Log("[GAME MANAGER] Actual Lives: " + lives + ".");
        return lives;
    }

    // Saves the heart count
    public void SaveLives(int saveHearts)
    {
        Debug.Log("[GAME MANAGER] Saving Lives.");
        uiController.SaveLives(saveHearts);
    }

    // Default settings
    public void SetDefault()
    {
        Debug.Log("[GAME MANAGER] Setting default Lives.");
        uiController.SetDefault();
    }

    // ---------------------------------------------------------------------------[ UI: Timer ]--------------------------------------------------------------------------------

    // Stops or plays the counting 
    public void PauseTimer(bool pause)
    {
        Debug.Log("[GAME MANAGER] Pause Timer " + pause + ".");
        uiController.PauseTimer(pause);
    }

    // Resets the timer to 0
    public void ResetTimer()
    {
        Debug.Log("[GAME MANAGER] Resest Timer.");
        uiController.ResetTimer();
    }

    // ---------------------------------------------------------------------------[ AUDIO ]------------------------------------------------------------------------------------

    // Get Audio Controller
    public AudioController GetAudioController()
    {
        return audioController;
    }

    // Sets the general volume
    public void SetVolume(float volume)
    {
        Debug.Log("[GAME MANAGER] Set volume to " + volume + ".");
        audioController.SetVolume(volume);
    }

    // Menu audio control
    public void GameStartAudio()
    {
        audioController.GameStartAudio();
    }

    public void GameOverAudio()
    {
        audioController.GameOverAudio();
    }

    // Background music control
    public void BackgroundAudio(string clip, bool play)
    {
        audioController.BackgroundAudio(clip, play);
    }

    // Player audio control
    public void PlayerAudio(AudioSource source, string clip, bool play)
    {
        audioController.PlayerAudio(source, clip, play);
    }

    public void PlayerEffects(string clip)
    {
        audioController.PlayerEffects(clip);
    }

    // Lever audio control
    public void LeverAudio(AudioSource source)
    {
        audioController.LeverAudio(source);
    }

    // Elevator audio control
    public void ElevatorAudio(AudioSource source, int clip, bool play)
    {
        audioController.ElevatorAudio(source, clip, play);
    }

    // Moving platform audio control
    public void MovingPlatformAudio(AudioSource source, bool play)
    {
        audioController.MovingPlatformAudio(source, play);
    }

    // Closing door audio control
    public void ClosingDoorAudio(AudioSource source)
    {
        audioController.ClosingDoorAudio(source);
    }

    // Plays the correct or incorrect audio
    public void CombinationAudio(AudioSource source, bool correct)
    {
        audioController.CombinationAudio(source, correct);
    }

    // Checkpoint audio control
    public void CheckPointAudio(AudioSource source)
    {
        audioController.CheckPointAudio(source);
    }

    // Life object audio control
    public void LifeObjectAudio()
    {
        audioController.LifeObjectAudio();
    }

    // Breaking rock audio control
    public void RockBreakAudio(AudioSource source)
    {
        audioController.RockBreakAudio(source);
    }

    // Falling box audio control
    public void FallBoxAudio(AudioSource source)
    {
        audioController.FallBoxAudio(source);
    }

    // ---------------------------------------------------------------------------[ ENDING ]-----------------------------------------------------------------------------------

    // Game ending and credits
    public void StartEnding()
    {

    }
}
