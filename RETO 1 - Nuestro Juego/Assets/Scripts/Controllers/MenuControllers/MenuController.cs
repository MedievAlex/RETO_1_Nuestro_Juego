using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

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
    void Start()
    {
        mainMenu = transform.GetChild(1).transform.GetComponent<MainMenuController>();
        optionsMenu = transform.GetChild(2).transform.GetComponent<OptionsMenuController>();
        pauseMenu = transform.GetChild(3).transform.GetComponent<PauseMenuController>();
        gameOverMenu = transform.GetChild(4).transform.GetComponent<GameOverMenuController>();

        EnsureEventSystem();  
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

    // Gets the number of the level
    public int GetLevel()
    {
        return gameManager.GetLevel();
    }

    // Sets the background for each level
    public void SetSpecificBackground(int level)
    {
        SetOptionsSpecificBackground(level);
        SetPauseSpecificBackground(level);
    }

    // ---------------------------------------------------------------------------[ Main Menu ]------------------------------------------------------------------------------------

    // Opens Main Menu
    public void OpenMainMenu()
    {
        mainMenu.SetActive(true);
    }

    // Loads the fist level
    public void GameStart()
    {
        gameManager.GameStart();
    }

    // ---------------------------------------------------------------------------[ Options Menu ]-----------------------------------------------------------------------------------

    // Opens Options Menu
    public void OpenOptionsMenu()
    {
        optionsMenu.SetActive(true);
    }

    // Sets the background for each level
    public void SetOptionsSpecificBackground(int level)
    {
        optionsMenu.SetSpecificBackground(level);
    }

    // ---------------------------------------------------------------------------[ Pause Menu ]---------------------------------------------------------------------------

        // Sets if it can be opened
    public void SetPauseActivable(bool activable)
    {
        pauseMenu.SetActivable(activable);
    }

    // Stops or plays the counting 
    public void PauseTimer(bool pause)
    {
        gameManager.PauseTimer(pause);
    }

    // Resets the timer to 0 
    public void ResetTimer()
    {
        gameManager.ResetTimer();
    }

    // Sets the background for each level
    public void SetPauseSpecificBackground(int level)
    {
        pauseMenu.SetSpecificBackground(level);
    }

    // ---------------------------------------------------------------------------[ Game Over Menu ]--------------------------------------------------------------------------------

    // Opens Game Over Menu
    public void OpenGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

    // Restarts the game
    public void RestartGame()
    {
        gameManager.RestartGame();
    }

    // ---------------------------------------------------------------------------[ The End Menu ]------------------------------------------------------------------------------------

    // Opens The End Menu
    public void OpenTheEndMenu()
    {

    }
}
