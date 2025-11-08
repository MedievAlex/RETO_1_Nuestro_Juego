using UnityEngine;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour
{
    // Visible variables
    [SerializeField] private GameObject Canvas;

    // Not visible variables
    private GameManager gameManager;
    private HealthBarController healthBarController;
    private TimerController timerController;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        gameManager = transform.parent.GetComponentInParent<GameManager>(); // Gets the Game Manager
        healthBarController = transform.GetChild(0).transform.GetChild(1).GetComponent<HealthBarController>(); // Gets the Health Bar Controller
        timerController = transform.GetChild(0).transform.GetChild(2).GetComponent<TimerController>(); // Gets the Timer Controller

        SetActive(false);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerController.PauseTimer(true);
        healthBarController.SetDefault();
    }

    // Open or close the menu
    public void SetActive(bool active)
    {
        if (Canvas != null)
        {
            Canvas.SetActive(active);
        }
    }

    // ---------------------------------------------------------------------------[ UI: Health Bar ]---------------------------------------------------------------------------

    // Updates life
    public void UpdateLives(int lives)
    {
        healthBarController.UpdateLives(lives);
    }

    // Gets the heart count
    public int GetLives()
    {
        return healthBarController.GetLives();
    }

    // Saves the heart count
    public void SaveLives(int saveHearts)
    {
        healthBarController.SaveLives(saveHearts);
    }

    // Default settings
    public void SetDefault()
    {
        healthBarController.SetDefault();
    }

    // ---------------------------------------------------------------------------[ UI: Timer ]--------------------------------------------------------------------------------

    // Stop or play the timer
    public void PauseTimer(bool pause)
    {
        timerController.PauseTimer(pause);
    }

    // Reset the value of the timer to 0
    public void ResetTimer()
    {
        timerController.ResetTimer();
    }

    // Game Over
    public void GameOver()
    {
        SceneManager.LoadScene("GameOverMenu", LoadSceneMode.Single);
        healthBarController.SetDefault();
        timerController.ResetTimer();
    }
}