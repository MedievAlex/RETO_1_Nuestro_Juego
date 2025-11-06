using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    // Visible variables
    private bool gameStopped = false;

    // Not visible variables
    private UIController uiController;
    private OptionsManager optionsMenu;
    [SerializeField] private GameObject Canvas; 
    private string menuScene = "MainMenu";

    void Start()
    {
        EnsureEventSystem();

        optionsMenu = GameObject.Find("Options").GetComponent<OptionsManager>();
        uiController = GameObject.Find("UI").GetComponent<UIController>(); // Finds the UIController of the Scene

        if (Canvas != null)
        {
            Canvas.SetActive(false);
        }
        SetupButtonsManually();
    }

    void SetupButtonsManually()
    {
        Button[] allButtons = GetComponentsInChildren<Button>(true);

        foreach (Button button in allButtons)
        {
            if (button.name.Contains("Resume"))
            {
                button.onClick.AddListener(ResumeGame);
            }
            else if (button.name.Contains("Options"))
            {
                button.onClick.AddListener(OptionsButton);
            }
            else if (button.name.Contains("Menu"))
            {
                button.onClick.AddListener(MenuButton);
            }

            button.interactable = true;
            Image btnImage = button.GetComponent<Image>();
            if (btnImage != null) btnImage.raycastTarget = true;
        }
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

        if (Input.GetKeyDown(KeyCode.T))
        {
            uiController.resetTimer();
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
            ResumeGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        Canvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
        Canvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ResumeButton()
    {
        ResumeGame();
    }

    public void OptionsButton()
    {
        optionsMenu.setActive(true);
    }

    public void MenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuScene);
    }
}