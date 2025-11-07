using UnityEngine;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour
{
    // Not visible variables
    private GameManager gameManager;
    private HealthBarController healthBarController;
    private TimerController timerController;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        gameManager = transform.parent.GetComponentInParent<GameManager>(); // Gets the Game Manager
        healthBarController = transform.GetChild(1).GetComponent<HealthBarController>(); // Gets the Health Bar Controller
        timerController = transform.GetChild(2).GetComponent<TimerController>(); // Gets the Timer Controller
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // ---------------------------------------------------------------------------[ UI: Health Bar ]---------------------------------------------------------------------------

    // Updates life
    public void setLife(int life)
    {
        healthBarController.setLife(life);
    }

    // Gets the heart count
    public int getLife()
    {
        return healthBarController.getLife();
    }

    // Saves the heart count
    public void saveLife(int saveHearts)
    {
        healthBarController.saveLife(saveHearts);
    }

    // ---------------------------------------------------------------------------[ UI: Timer ]--------------------------------------------------------------------------------

    // Stop or play the timer
    public void ToggleTimer(bool pause)
    {
        timerController.ToggleTimer(pause);
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