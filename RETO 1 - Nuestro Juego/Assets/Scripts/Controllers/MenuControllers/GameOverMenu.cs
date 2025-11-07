using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    // Visible variables
    [Header("Buttons")] // Makes a header on the public variables
    public Button restartButton;
    public Button mainMenuButton;

    // Not visible variables
    private MenuController menuController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menuController = transform.parent.GetComponentInParent<MenuController>(); // Gets the Menu Controller

        restartButton.onClick.AddListener(RestartGame); // When clicking Retry button restarts the game
        mainMenuButton.onClick.AddListener(OpenMainMenu); // When clicking Menu button goes back to the main menu
    }

    // Restarts the Game
    private void RestartGame()
    {
        menuController.RestartGame();
    }

    // Opens Main Menu
    private void OpenMainMenu()
    {
        menuController.OpenMainMenu();
    }
}