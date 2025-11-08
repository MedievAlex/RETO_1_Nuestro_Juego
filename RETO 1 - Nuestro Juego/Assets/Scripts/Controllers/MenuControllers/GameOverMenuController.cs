using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenuController : MonoBehaviour
{
    // Visible variables
    [Header("Controller")] // Makes a header on the public variables
    public MenuController menuController;

    [Header("Canvas")] // Makes a header on the public variables
    [SerializeField] private GameObject Canvas;

    [Header("Buttons")] // Makes a header on the public variables
    public Button restartButton;
    public Button mainMenuButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("[GameOverMenu] Setting Buttons.");
        restartButton.onClick.AddListener(RestartGame); // When clicking Retry button restarts the game
        mainMenuButton.onClick.AddListener(OpenMainMenu); // When clicking Menu button goes back to the main menu
    }

    // Open or close the menu
    public void SetActive(bool active)
    { 
        if (Canvas != null)
        {
            Debug.Log("[GameOverMenu] Active " + active + ".");
            Canvas.SetActive(active);
        }
    }

    // Restarts the Game
    private void RestartGame()
    {
        Debug.Log("[GameOverMenu] Game Restart.");
        menuController.RestartGame();
        SetActive(false);
    }

    // Opens Main Menu
    private void OpenMainMenu()
    {
        Debug.Log("[GameOverMenu] Open Main Menu.");
        menuController.OpenMainMenu(true);
        SetActive(false);
    }
}