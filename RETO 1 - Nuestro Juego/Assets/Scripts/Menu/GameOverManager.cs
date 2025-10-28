using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [Header("Botones")]
    public Button retryButton;
    public Button menuButton;

    private string levelScene = "Level-1";
    private string MainMenuScene = "MainMenu";

    void Start()
    {
        retryButton.onClick.AddListener(() => {
            SceneManager.LoadScene(levelScene, LoadSceneMode.Single);
        });

        menuButton.onClick.AddListener(() => {
            SceneManager.LoadScene(MainMenuScene, LoadSceneMode.Single);
        });
    }
}