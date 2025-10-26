using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    // Not visible variables
    [SerializeField] private GameObject Canvas;
    private bool gameStopped = false;

    private string menuScene = "MainMenu";
    private string optionsMenuScene = "OptionsMenu";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnsureEventSystem();

        if (Canvas != null)
        {
            Canvas.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
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

    public void TogglePause()
    {
        gameStopped = !gameStopped;

        if (gameStopped)
        {
            PauseGame();
        }
        else
        {
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
        Time.timeScale = 1f;
        SceneManager.LoadScene(optionsMenuScene);
    }

    public void MenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuScene);
    }

}