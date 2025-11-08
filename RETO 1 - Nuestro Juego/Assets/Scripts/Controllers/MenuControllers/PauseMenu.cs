using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    // Visible variables
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
    private MenuController menuController;

    private Image backgroundImage;

    private bool activable = false;
    private bool pause = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menuController = transform.parent.GetComponentInParent<MenuController>(); // Gets the Menu Controller

        backgroundImage = transform.GetChild(0).transform.GetChild(0).transform.GetComponent<Image>();
        
        SetActive(false);

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
        this.activable = activable;
    }

    // Opens or closes the menu
    public void TogglePause()
    {
        pause = !pause;

        if (pause)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            menuController.PauseTimer(true);
            SetActive(true);
        }
        else
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            menuController.PauseTimer(false);
            SetActive(false);
        }
    }

    // Open or close the menu
    public void SetActive(bool active)
    {
        if (Canvas != null)
        {
            Canvas.SetActive(active);
        }
    }

    // Sets the background for each level
    public void SetSpecificBackground(int level)
    {
        switch (level)
        {
            case 1:
                backgroundImage.sprite = firstLevelBackground;
                break;

            case 2:
                backgroundImage.sprite = secondLevelBackground;
                break;

            case 3:
                backgroundImage.sprite = thirdLevelBackground;
                break;
        }
    }

    // Goes back to the Main Menu
    public void OpenMainMenu()
    {
        menuController.OpenMainMenu();
    }

    // Opens the Options Menu
    public void OpenOptionsMenu()
    {
        menuController.OpenOptionsMenu();
    }
}