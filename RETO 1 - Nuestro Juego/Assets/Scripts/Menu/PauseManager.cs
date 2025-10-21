using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject Canvas;
    private bool gameStopped = false;

    [Header("Referencias")]
    public string menuScene = "MainMenu";
    public string optionsMenuScene = "OptionsMenu";

    void Start()
    {
        // Asegurar que hay un EventSystem en la escena
        EnsureEventSystem();

        if (Canvas != null)
        {
            Canvas.SetActive(false);
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
            Debug.Log("EventSystem creado para esta escena");
        }
        else if (eventSystems.Length > 1)
        {
            for (int i = 1; i < eventSystems.Length; i++)
            {
                Destroy(eventSystems[i].gameObject);
            }
            Debug.Log($"Eliminados {eventSystems.Length - 1} EventSystems duplicados");
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
        Debug.Log("=== BOTÓN REANUDAR CLICKEADO ===");
        ResumeGame();
    }

    public void OptionsButton()
    {
        Debug.Log("=== BOTÓN OPCIONES CLICKEADO ===");
        Time.timeScale = 1f;
        SceneManager.LoadScene(optionsMenuScene);
    }

    public void MenuButton()
    {
        Debug.Log("=== BOTÓN MENÚ CLICKEADO ===");
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuScene);
    }
}