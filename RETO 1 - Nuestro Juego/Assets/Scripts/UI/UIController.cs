using UnityEngine;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour
{

    // Not visible variables
    private static UIController Instance;
    private HealthBarController healthBarController;
    private TimerController timerController;

    void Awake()
    {
        if (Instance == null)
        {
            healthBarController = transform.GetChild(1).GetComponent<HealthBarController>();
            timerController = transform.GetChild(2).GetComponent<TimerController>();
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // [ HEALTH BAR METHODS ]
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

    // [ TIMER METHODS ]

    public void pauseTimer(bool pause)
    {
        timerController.setPause(pause);
    }

    public void resetTimer()
    {
        timerController.resetTime();
    }

    // Game Over
    public void gameOver()
    {
        SceneManager.LoadScene("GameOverMenu", LoadSceneMode.Single);
        healthBarController.setDefault();
        timerController.resetTime();
    }
}