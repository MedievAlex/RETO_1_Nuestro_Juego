using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Not visible variables
    private GameManager gameManager;

    private OptionsMenu optionsMenu;
    private PauseMenu pauseMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = transform.parent.GetComponentInParent<GameManager>(); // Gets the Game Manager

        optionsMenu = transform.GetChild(0).transform.GetComponent<OptionsMenu>();
        pauseMenu = transform.GetChild(1).transform.GetComponent<PauseMenu>();

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

    // ---------------------------------------------------------------------------[ Main Menu ]------------------------------------------------------------------------------------

    // Opens Main Menu
    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
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

    // ---------------------------------------------------------------------------[ Pause Menu ]---------------------------------------------------------------------------

    // Sets if it can be opened
    public void SetPauseActivable(bool activable)
    {
        pauseMenu.SetActivable(activable);
    }

    // Stops or plays the counting 
    public void ToggleTimer(bool pause)
    {
        gameManager.PauseTimer(pause);
    }

    // ---------------------------------------------------------------------------[ Game Over Menu ]--------------------------------------------------------------------------------

    // Opens Game Over Menu
    public void OpenGameOverMenu()
    {
        SceneManager.LoadScene("GameOverMenu", LoadSceneMode.Single);
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
