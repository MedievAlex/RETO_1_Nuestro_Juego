using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Visible variables
    [Header("Player")] // Makes a header on the public variables
    public PlayerControl2D player;

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
        levelController.MainMenu();
        Debug.Log("[GAME MANAGER] Starting Menus.");
        menuController.StartSettings();
        Debug.Log("[GAME MANAGER] Starting UI.");
        uiController.StartSettings();
    }

    // ---------------------------------------------------------------------------[ Menu ]------------------------------------------------------------------------------------

    // Opens Main Menu
    public void OpenMainMenu(bool active)
    {
        Debug.Log("[GAME MANAGER] Open Main Menu " + active + ".");
        ActivateUI(!active);
        menuController.SetPauseActivable(!active);
        levelController.MainMenu();
        menuController.OpenMainMenu(active);
        audioController.backgroundAudio("MENU", active);
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
        menuController.SetPauseActivable(!active);
        audioController.gameOverAudio(GetComponent<AudioSource>());
        menuController.OpenGameOverMenu(active);
    }

    // ---------------------------------------------------------------------------[ Level ]------------------------------------------------------------------------------------

    // Loads the fist level
    public void GameStart()
    {
        Debug.Log("[GAME MANAGER] Starting Game.");
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
    public void SetPlayer(PlayerControl2D player)
    {
        Debug.Log("[GAME MANAGER] Setting Player.");
        this.player = player;
    }

    // ---------------------------------------------------------------------------[ UI ]---------------------------------------------------------------------------------------

    // Activates or deactivates the UI
    public void ActivateUI(bool active)
    {
        Debug.Log("[GAME MANAGER] Active UI " + active + ".");
        uiController.SetActive(active);
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

    public AudioController GetAudioController()
    {
        return audioController;
    }

    public void GameStartAudio()
    {
        audioController.GameStartAudio();
    } 
}
