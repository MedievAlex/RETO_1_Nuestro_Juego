using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;

public class MenuManager : MonoBehaviour
{
    // Visible vaiables
    [Header("Buttons")] // Makes a header on the public variables
    public Button playButton;
    public Button exitButton;
    public Button optionsButton;

    // Not visible variables
    private UIController uiController;
    private AudioController audioController;
    private OptionsManager optionsMenu;
    private string levelScene = "Level-1";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiController = GameObject.Find("UI").GetComponent<UIController>(); // Finds the UIController of the Scene
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>(); // Finds the AudioController of the Scene
        optionsMenu = GameObject.Find("Options").GetComponent<OptionsManager>(); // Finds the OptionsManager of the Scene

        playButton.onClick.AddListener(play); // When clicking Play button starts the game
        exitButton.onClick.AddListener(exit); // When clicking Exit button closes the game
        optionsButton.onClick.AddListener(options); // When clicking Options button opens the options menu
    }

    private void play()
    {
        audioController.gameStartAudio();
        SceneManager.LoadScene(levelScene, LoadSceneMode.Single);
        audioController.backgroundAudio("FOREST", true);
        uiController.resetTimer();
        uiController.pauseTimer(false);
        Destroy(GameObject.Find("MainCamera").GetComponent<MainCameraController>()); // Destroys the main camera
    }

    private void exit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    private void options()
    {
        optionsMenu.setActive(true);
    }
}