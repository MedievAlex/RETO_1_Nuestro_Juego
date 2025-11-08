using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    // Visible variables
    [Header("Controller")] // Makes a header on the public variables
    public MenuController menuController;

    [Header("Canvas")] // Makes a header on the public variables
    [SerializeField] private GameObject Canvas;

    [Header("Buttons")] // Makes a header on the public variables
    public Button resumeButton;
    public Button mainMenuButton;
    public Button optionsButton;

    [Header("Backgrounds")] // Makes a header on the public variables
    public Sprite firstLevelBackground;
    public Sprite secondLevelBackground;
    public Sprite thirdLevelBackground;

    // Not visible variables
    private Image backgroundImage;

    private bool activable = false;
    private bool pause = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("[PauseMenu] Getting Background.");
        backgroundImage = transform.GetChild(0).transform.GetChild(0).transform.GetComponent<Image>();

        Debug.Log("[PauseMenu] Setting Buttons.");
        resumeButton.onClick.AddListener(TogglePause); // When clicking Resume button goes back to the game
        mainMenuButton.onClick.AddListener(OpenMainMenu); // When clicking Menu button goes back to the main menu
        optionsButton.onClick.AddListener(OpenOptionsMenu); // When clicking Options button opens the options menu 
    }

    // Update is called once per frame
    void Update()
    {
        if (activable && Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    // Sets if it can be opened
    public void SetActivable(bool activable)
    {
        Debug.Log("[PauseMenu] Activable " + activable + ".");
        this.activable = activable;
    }

    // Open or close the menu
    public void SetActive(bool active)
    {
        if (Canvas != null)
        {
            Debug.Log("[PauseMenu] Active " + active + ".");
            Canvas.SetActive(active);
        }
    }

    // Opens or closes the menu
    private void TogglePause()
    {
        Debug.Log("[PauseMenu] State changed to " + !pause + ".");
        pause = !pause;

        if (pause)
        {
            Time.timeScale = 0f;
            Debug.Log("[PauseMenu] Time Scale " + Time.timeScale + ".");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            menuController.PauseTimer(true);
            SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            Debug.Log("[PauseMenu] Time Scale " + Time.timeScale + ".");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            menuController.PauseTimer(false);
            SetActive(false);
        }
    }

    // Sets the background for each level
    public void SetSpecificBackground(int level)
    {
        switch (level)
        {
            case 0:
                Debug.Log("[PauseMenu] Setting Background for Level-" + (level++) + ".");
                backgroundImage.sprite = firstLevelBackground;
                break;

            case 1:
                Debug.Log("[PauseMenu] Setting Background for Level-" + level + ".");
                backgroundImage.sprite = firstLevelBackground;
                break;

            case 2:
                Debug.Log("[PauseMenu] Setting Background for Level-" + level + ".");
                backgroundImage.sprite = secondLevelBackground;
                break;

            case 3:
                Debug.Log("[PauseMenu] Setting Background for Level-" + level + ".");
                backgroundImage.sprite = thirdLevelBackground;
                break;
        }
    }

    // Goes back to the Main Menu
    private void OpenMainMenu()
    {
        Debug.Log("[PauseMenu] Open Main Menu.");
        menuController.OpenMainMenu(true);
        TogglePause();
    }

    // Opens the Options Menu
    private void OpenOptionsMenu()
    {
        Debug.Log("[PauseMenu] Open Options Menu.");
        menuController.OpenOptionsMenu(true);
    }
}