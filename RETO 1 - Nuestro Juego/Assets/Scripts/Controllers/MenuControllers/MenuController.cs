using UnityEngine;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{
    // Visible variables
    [Header("Manager")] // Makes a header on the public variables
    public GameManager gameManager;

    // Not visible variables
    private MainMenuController mainMenu;
    private OptionsMenuController optionsMenu;
    private PauseMenuController pauseMenu;
    private GameOverMenuController gameOverMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Debug.Log("[MenuController] Setting Menus.");
        mainMenu = transform.GetChild(1).transform.GetComponent<MainMenuController>();
        optionsMenu = transform.GetChild(2).transform.GetComponent<OptionsMenuController>();
        pauseMenu = transform.GetChild(3).transform.GetComponent<PauseMenuController>();
        gameOverMenu = transform.GetChild(4).transform.GetComponent<GameOverMenuController>();
    }

    // Sets the values for the start
    public void StartSettings()
    {
        Debug.Log("[MenuController] Starting Menus.");

        EnsureEventSystem();

        OpenPauseMenu(false);
        SetPauseActivable(false);

        OpenOptionsMenu(false);

        OpenGameOverMenu(false);

        OpenMainMenu(true);
    }

    // To use buttons
    private void EnsureEventSystem()
    {
        EventSystem[] eventSystems = FindObjectsByType<EventSystem>(FindObjectsSortMode.None);

        if (eventSystems.Length == 0)
        {
            GameObject eventSystem = new("EventSystem");
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();
        }
        else if (eventSystems.Length > 1)
        {
            for (int i = 1; i < eventSystems.Length; i++)
            {
                Destroy(eventSystems[i].gameObject);
            }
        }
    }

    // Loads the fist level
    public void GameStart()
    {
        Debug.Log("[MenuController] Game Start.");
        gameManager.GameStartAudio();
        OpenGameOverMenu(false);
        SetPauseActivable(true);
        gameManager.GameStart();
    }

    // Gets the number of the level
    public int GetLevel()
    {
        int level = gameManager.GetLevel();
        Debug.Log("[MenuController] Actual Level: Level-" + level + ".");
        return level;
    }

    // Sets the background for each level
    public void SetSpecificBackground(int level)
    {
        Debug.Log("[MenuController] Setting Backgrounds for Level-" + level + ".");
        SetOptionsSpecificBackground(level);
        SetPauseSpecificBackground(level);
    }

    // ---------------------------------------------------------------------------[ Main Menu ]------------------------------------------------------------------------------------

    // Opens Main Menu
    public void OpenMainMenu(bool active)
    {
        Debug.Log("[MenuController] Opening Main Menu " + active + ".");
        SetPauseActivable(false);
        gameManager.OpenMainMenu(active);
        mainMenu.SetActive(active);
        gameManager.BackgroundAudio("MENU", true);
    }

    // Closes the Game
    public void CloseGame()
    {
        gameManager.CloseGame();
    }

    // ---------------------------------------------------------------------------[ Options Menu ]-----------------------------------------------------------------------------------

    // Opens Options Menu
    public void OpenOptionsMenu(bool active)
    {
        Debug.Log("[MenuController] Opening Options Menu " + active + "."); 
        SetPauseActivable(false);
        optionsMenu.SetActive(active);
    }

    // Sets the background for each level
    private void SetOptionsSpecificBackground(int level)
    {
        Debug.Log("[MenuController] Setting Options Menu Background for Level-" + level + ".");
        optionsMenu.SetSpecificBackground(level);
    }

    // Sets the general volume
    public void SetVolume(float volume)
    {
        gameManager.SetVolume(volume);
    }

    // ---------------------------------------------------------------------------[ Pause Menu ]---------------------------------------------------------------------------

    // Sets if it can be opened
    public void SetPauseActivable(bool activable)
    {
        Debug.Log("[MenuController] Set Pause Menu activable" + activable + ".");
        pauseMenu.SetActivable(activable);
    }

    // Opens Options Menu
    public void OpenPauseMenu(bool active)
    {
        Debug.Log("[MenuController] Opening Pause Menu " + active + ".");
        pauseMenu.SetActive(active);
    }

    // Stops or plays the counting 
    public void PauseTimer(bool pause)
    {
        Debug.Log("[MenuController] Pause Timer " + pause + ".");
        gameManager.PauseTimer(pause);
    }

    // Resets the timer to 0 
    public void ResetTimer()
    {
        Debug.Log("[MenuController] Resest Timer.");
        gameManager.ResetTimer();
    }

    // Sets the background for each level
    private void SetPauseSpecificBackground(int level)
    {
        Debug.Log("[MenuController] Setting Pause Menu Background for Level-" + level + ".");
        pauseMenu.SetSpecificBackground(level);
    }

    // ---------------------------------------------------------------------------[ Game Over Menu ]--------------------------------------------------------------------------------

    // Opens Game Over Menu
    public void OpenGameOverMenu(bool active)
    {
        Debug.Log("[MenuController] Opening Game Over Menu " + active + ".");
        SetPauseActivable(false);
        gameManager.OpenMainMenu(active);
        gameOverMenu.SetActive(active);
        if (active)
        {
            gameManager.GameOverAudio();
        }
    }

    // Restarts the game
    public void RestartGame()
    {
        Debug.Log("[MenuController] Restart Game.");
        gameManager.RestartGame();
    }

    // ---------------------------------------------------------------------------[ The End Menu ]------------------------------------------------------------------------------------

    // Opens The End Menu
    public void OpenTheEndMenu()
    {

    }
}
