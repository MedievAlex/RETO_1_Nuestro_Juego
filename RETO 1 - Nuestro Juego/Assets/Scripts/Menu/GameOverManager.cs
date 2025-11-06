using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    // Visible variables
    [Header("Botones")]
    public Button retryButton;
    public Button menuButton;

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

        retryButton.onClick.AddListener(retry);

        menuButton.onClick.AddListener(mainMenu);

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