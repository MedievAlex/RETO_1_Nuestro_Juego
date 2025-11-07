using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenuController : MonoBehaviour
{
    // Visible variables
    [Header("Buttons")] // Makes a header on the public variables
    public Button retryButton;
    public Button mainMenuButton;

    // Not visible variables
    private UIController uiController;
    private AudioController audioController;
    private string levelScene = "Level-1";
    private string MainMenuScene = "MainMenu";

    void Start()
    {
        uiController = GameObject.Find("UI").GetComponent<UIController>(); // Finds the UIController of the Scene
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>(); // Finds the AudioController of the Scene
        audioController.gameOverAudio(GetComponent<AudioSource>());

        retryButton.onClick.AddListener(retry); // When clicking Retry button restarts the game

        mainMenuButton.onClick.AddListener(mainMenu); // When clicking Menu button goes back to the main menu

        uiController.pauseTimer(true);
    }

    private void retry()
    {
        audioController.backgroundAudio("FOREST", true);
        SceneManager.LoadScene(levelScene, LoadSceneMode.Single);
        uiController.resetTimer();
        uiController.pauseTimer(false);
    }

    private void mainMenu()
    {
        SceneManager.LoadScene(MainMenuScene, LoadSceneMode.Single);
    }
}