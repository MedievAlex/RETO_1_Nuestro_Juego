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
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // ---------------------------------------------------------------------------[ Menu ]------------------------------------------------------------------------------------

    // Opens Main Menu
    public void OpenMainMenu()
    {
        menuController.SetPauseActivable(false);
        menuController.OpenMainMenu();
        audioController.backgroundAudio("MENU", true);
    }

    // Opens Options Menu
    public void OpenOptionsMenu()
    {
        menuController.OpenOptionsMenu();
    }

    // Sets the background for each level
    public void SetSpecificBackground(int level)
    {
        menuController.SetSpecificBackground(level);
    }

    // Opens Game Over Menu
    public void OpenGameOverMenu()
    {
        ActivateUI(false);
        menuController.SetPauseActivable(false);
        audioController.gameOverAudio(GetComponent<AudioSource>());
        menuController.OpenGameOverMenu();
    }

    // ---------------------------------------------------------------------------[ Level ]------------------------------------------------------------------------------------

    // Loads the fist level
    public void GameStart()
    {
        levelController.GameStart();
        ActivateUI(true);
        ResetTimer();
        PauseTimer(false);
        menuController.SetPauseActivable(true);
    }

    // Loads the next level
    public void NextLevel()
    {
        levelController.NextLevel();
    }

    // Restart the Game and Timer
    public void RestartGame()
    {
        levelController.RestartGame();
        ActivateUI(true);
        menuController.SetPauseActivable(true);
        ResetTimer();
        PauseTimer(false);
    }

    // Gets the number of the level
    public int GetLevel()
    {
        return levelController.GetLevel();
    }

    // ---------------------------------------------------------------------------[ Player ]-----------------------------------------------------------------------------------

    // Sets the current player
    public void SetPlayer(PlayerControl2D player)
    {
        this.player = player;
    }

    // ---------------------------------------------------------------------------[ UI ]---------------------------------------------------------------------------------------

    // Activates or deactivates the UI
    public void ActivateUI(bool active)
    {
        uiController.SetActive(active);
    }

    // ---------------------------------------------------------------------------[ UI: Health Bar ]---------------------------------------------------------------------------

    // Updates life
    public void UpdateLives(int lives)
    {
        uiController.UpdateLives(lives);
    }

    // Gets the heart count
    public int GetLives()
    {
        return uiController.GetLives();
    }

    // Saves the heart count
    public void SaveLives(int saveHearts)
    {
        uiController.SaveLives(saveHearts);
    }

    // Default settings
    public void SetDefault()
    {
        uiController.SetDefault();
    }

    // ---------------------------------------------------------------------------[ UI: Timer ]--------------------------------------------------------------------------------

    // Stops or plays the counting 
    public void PauseTimer(bool pause)
    {
        uiController.PauseTimer(pause);
    }

    // Resets the timer to 0
    public void ResetTimer()
    {
        uiController.ResetTimer();
    }

    // ---------------------------------------------------------------------------[ AUDIO ]------------------------------------------------------------------------------------

    public void GameStartAudio()
    {
        audioController.GameStartAudio();
    }

}
