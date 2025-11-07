using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    // Visible variables
    [SerializeField] private GameObject Canvas;

    [Header("Buttons")] // Makes a header on the public variables
    public Button resumeButton;
    public Button mainMenuButton;
    public Button optionsButton;

    // Not visible variables
    private UIController uiController;
    private OptionsMenuController optionsMenu;
    private bool gameStopped = false;
    private string menuScene = "MainMenu";

    void Start()
    {
        EnsureEventSystem();

        optionsMenu = GameObject.Find("Options").GetComponent<OptionsMenuController>();
        uiController = GameObject.Find("UI").GetComponent<UIController>(); // Finds the UIController of the Scene

        if (Canvas != null)
        {
            Canvas.SetActive(false);
        }

        resumeButton.onClick.AddListener(resume); // When clicking Resume button goes back to the game
        mainMenuButton.onClick.AddListener(mainMenu); // When clicking Menu button goes back to the main menu
        optionsButton.onClick.AddListener(options); // When clicking Options button opens the options menu 
    }


    void EnsureEventSystem()
    {
        EventSystem[] eventSystems = FindObjectsByType<EventSystem>(FindObjectsSortMode.None);

        if (eventSystems.Length == 0)
        {
            GameObject eventSystem = new("EventSystem");
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();
        }
        else if (eventSystems.Length > 1)
        {
            for (int i = 1; i < eventSystems.Length; i++)
            {
                Destroy(eventSystems[i].gameObject);
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        gameStopped = !gameStopped;

        if (gameStopped)
        {
            uiController.pauseTimer(true);
            PauseGame();
        }
        else
        {
            uiController.pauseTimer(false);
            resume();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        Canvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void resume()
    {
        Time.timeScale = 1f;
        Canvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ResumeButton()
    {
        resume();
    }

    public void options()
    {
        optionsMenu.setActive(true);
    }

    public void mainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuScene);
        uiController.resetTimer();
    }
}