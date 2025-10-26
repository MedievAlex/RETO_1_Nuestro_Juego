using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    // Visible vaiables
    [Header("Buttons")] // Makes a header on the public variables
    public Button playButton;
    public Button optionsButton;
    public Button exitButton;

    // Not visible variables
    private string levelScene = "Level-1";
    private string optionsMenuScene = "OptionsMenu";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playButton.onClick.AddListener(() => { // When clicking Play button starts the game
            SceneManager.LoadScene(levelScene, LoadSceneMode.Single);
            Destroy(GameObject.Find("MainCamera").GetComponent<MainCameraController>()); // Destroys the main camera
        });

        optionsButton.onClick.AddListener(() => { // When clicking Options button opens the options menu
            SceneManager.LoadScene(optionsMenuScene, LoadSceneMode.Single);
        });

        exitButton.onClick.AddListener(() => { // When clicking Exit button closes the game
            Debug.Log("Saliendo del juego...");
            Application.Quit();
        });
    }
}