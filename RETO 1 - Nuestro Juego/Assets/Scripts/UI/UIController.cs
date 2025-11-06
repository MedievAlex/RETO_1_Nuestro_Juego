using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{

    // Not visible variables
    private static UIController Instance;
    private static HealthBarController healthBarController;

    void Awake()
    {
        healthBarController = transform.GetChild(0).GetComponent<HealthBarController>();

        if (Instance == null)
        {
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

    // Game Over
    public void gameOver()
    {
        SceneManager.LoadScene("GameOverMenu", LoadSceneMode.Single);
        healthBarController.setDefault();
    }
}