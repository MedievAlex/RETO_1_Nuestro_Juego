using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    // Visible variables
    [Header("Controller")] // Makes a header on the public variables
    public MenuController menuController;

    [Header("Canvas")] // Makes a header on the public variables
    [SerializeField] private GameObject Canvas;

    [Header("Buttons")] // Makes a header on the public variables
    public Button playButton;
    public Button exitButton;
    public Button optionsButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("[MainMenu] Setting Buttons.");
        playButton.onClick.AddListener(GameStart); // When clicking Play button starts the game
        exitButton.onClick.AddListener(ExitGame); // When clicking Exit button closes the game
        optionsButton.onClick.AddListener(OpenOptionsMenu); // When clicking Options button opens the Options Menu
    }

    // Open or close the menu
    public void SetActive(bool active)
    {
        if (Canvas != null)
        {
            Debug.Log("[MainMenu] Active " + active + ".");
            Canvas.SetActive(active);
        }
    }

    // Loads the fist level
    private void GameStart()
    {
        Debug.Log("[MainMenu] Game Start.");
        menuController.GameStart();
        SetActive(false);
    }

    // Opens the Options Menu
    private void OpenOptionsMenu()
    {
        Debug.Log("[MainMenu] Open Options Menu.");
        menuController.OpenOptionsMenu(true);
    }

    // Closes the Game
    private void ExitGame()
    {
        Debug.LogWarning("[MainMenu] Closing the Game.");
        menuController.CloseGame();
    }
}