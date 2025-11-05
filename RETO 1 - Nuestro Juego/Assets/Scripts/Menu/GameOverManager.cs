using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    // Visible variables
    [Header("Botones")]
    public Button retryButton;
    public Button menuButton;

    // Not visible variables
    private AudioController audioController;
    private string levelScene = "Level-1";
    private string MainMenuScene = "MainMenu";

    void Start()
    {
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>(); // Finds the AudioController of the Scene
        audioController.gameOverAudio(GetComponent<AudioSource>());

        retryButton.onClick.AddListener(() => {
            audioController.backgroundAudio("FOREST", true);
            SceneManager.LoadScene(levelScene, LoadSceneMode.Single);   
        });

        menuButton.onClick.AddListener(() => {
            SceneManager.LoadScene(MainMenuScene, LoadSceneMode.Single);
        });
    }
}