using UnityEngine;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour
{
    // Visible variables
    [Header("Manager")] // Makes a header on the public variables
    public GameManager gameManager;

    [Header("Canvas")] // Makes a header on the public variables
    [SerializeField] private GameObject Canvas;

    // Not visible variables
    private HealthBarController healthBarController;
    private TimerController timerController;
    private DamageBorderController damageBorder;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        Debug.Log("[UIController] Setting Elements.");
        healthBarController = transform.GetChild(0).transform.GetChild(1).GetComponent<HealthBarController>(); // Gets the Health Bar Controller
        timerController = transform.GetChild(0).transform.GetChild(2).GetComponent<TimerController>(); // Gets the Timer Controller
        damageBorder  = transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<DamageBorderController>(); // Gets the Damage Border Controller
    }

    // Sets the values for the start
    public void StartSettings()
    {
        SetActive(false);

        Debug.Log("[UIController] Starting Elements.");
        SetDefault();
        PauseTimer(true); 
        ShowDamageBorder(false, 0f);
    }

    // Open or close the menu
    public void SetActive(bool active)
    {
        if (Canvas != null)
        {
            Debug.Log("[UIController] Active " + active + ".");
            Canvas.SetActive(active);
        }
    }

    // ---------------------------------------------------------------------------[ UI: Health Bar ]---------------------------------------------------------------------------

    // Updates life
    public void UpdateLives(int lives)
    {
        Debug.Log("[UIController] Updating Lives to.");
        healthBarController.UpdateLives(lives);
    }

    // Gets the heart count
    public int GetLives()
    {
        Debug.Log("[UIController] Getting Lives.");
        return healthBarController.GetLives();
    }

    // Saves the heart count
    public void SaveLives(int saveHearts)
    {
        Debug.Log("[UIController] Saving Lives.");
        healthBarController.SaveLives(saveHearts);
    }

    // Default settings
    public void SetDefault()
    {
        Debug.Log("[UIController] Setting Health Bar to default values.");
        healthBarController.SetDefault();
    }

    // ---------------------------------------------------------------------------[ UI: Timer ]--------------------------------------------------------------------------------

    // Stop or play the timer
    public void PauseTimer(bool pause)
    {
        Debug.Log("[UIController] Pause Timer " + pause + ".");
        timerController.PauseTimer(pause);
    }

    // Reset the value of the timer to 0
    public void ResetTimer()
    {
        Debug.Log("[UIController] Reseting Timer.");
        timerController.ResetTimer();
    }

    // Deals damage
    public void ApplyDamage()
    {
        gameManager.ApplyDamage();
    }

    // Game Over
    public void GameOver()
    {
        gameManager.OpenGameOverMenu(true);
        healthBarController.SetDefault();
        timerController.ResetTimer();
    }

    // ---------------------------------------------------------------------------[ UI: Damage Border ]--------------------------------------------------------------------------------

    // Shows or hides the border
    public void ShowDamageBorder(bool visible, float visibleSeconds)
    {
        Debug.Log("[UIController] Damage Border visible " + visible + ".");
        damageBorder.ShowDamageBorder(visible, visibleSeconds);
    }
}