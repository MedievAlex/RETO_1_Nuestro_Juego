using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Visible vaiables
    [SerializeField] private GameObject Canvas;

    [Header("Buttons")] // Makes a header on the public variables
    public Button playButton;
    public Button exitButton;
    public Button optionsButton;

    // Not visible variables
    private MenuController menuController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menuController = transform.parent.GetComponentInParent<MenuController>(); // Gets the Menu Controller

        SetActive(true);

        playButton.onClick.AddListener(GameStart); // When clicking Play button starts the game
        exitButton.onClick.AddListener(ExitGame); // When clicking Exit button closes the game
        optionsButton.onClick.AddListener(OpenOptionsMenu); // When clicking Options button opens the Options Menu
    }

    // Open or close the menu
    public void SetActive(bool active)
    {
        if (Canvas != null)
        {
            Canvas.SetActive(active);
        }
    }

    // Loads the fist level
    private void GameStart()
    {
        menuController.GameStart();
        SetActive(false);
    }

    // Opens the Options Menu
    public void OpenOptionsMenu()
    {
        menuController.OpenOptionsMenu();
    }

    // Closes the Game
    private void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}