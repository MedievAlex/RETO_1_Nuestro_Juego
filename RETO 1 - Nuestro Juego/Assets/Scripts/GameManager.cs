using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager Instance;
    private MenuController menuController;
    private LevelController levelController;
    private UIController uiController;
    private AudioController audioController;
    private PlayerControl2D player;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Payer2D").GetComponent<PlayerControl2D>(); // Finds the Player of the Scene
        uiController = GameObject.Find("UI").GetComponent<UIController>(); // Finds the UIController of the Scene
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>(); // Finds the AudioController of the Scene
    }

    // Update is called once per frame
    void Update()
    {

    }

    // ---------------------------------------------------------------------------[ Menu ]------------------------------------------------------------------------------------

    // Opens Main Menu
    public void OpenMainMenu()
    {
        menuController.SetPauseActivable(false);
        menuController.OpenMainMenu();
        audioController.backgroundAudio("MENU", true);
    }

    // Opens Options Menu
    public void OpenOptionsMenu()
    {
        menuController.OpenOptionsMenu();
    }

    // Opens Game Over Menu
    public void OpenGameOverMenu()
    {
        menuController.SetPauseActivable(false);
        audioController.gameOverAudio(GetComponent<AudioSource>());
        menuController.OpenGameOverMenu();
    }

    // ---------------------------------------------------------------------------[ Level ]------------------------------------------------------------------------------------

    // Loads the fist level
    public void GameStart()
    {
        levelController.GameStart();
        menuController.SetPauseActivable(true);
    }

    // Loads the next level
    public void NextLevel()
    {
        levelController.NextLevel();
    }

    // Restart the Game and Timer
    public void RestartGame()
    {
        levelController.RestartGame();
        menuController.SetPauseActivable(true);
        uiController.ResetTimer();
        uiController.ToggleTimer(false);
    }

    // ---------------------------------------------------------------------------[ Player ]-----------------------------------------------------------------------------------



    // ---------------------------------------------------------------------------[ UI: Health Bar ]---------------------------------------------------------------------------



    // ---------------------------------------------------------------------------[ UI: Timer ]--------------------------------------------------------------------------------

    // Stops or plays the counting 
    public void ToggleTimer(bool pause)
    {
        uiController.ToggleTimer(pause);
    }

    // Resets the timer to 0
    public void ResetTimer()
    {
        uiController.ResetTimer();
    }

    // ---------------------------------------------------------------------------[ AUDIO ]------------------------------------------------------------------------------------

    public void GameStartAudio()
    {
        audioController.GameStartAudio();
    }

    // ---------------------------------------------------------------------------[ AUDIO ]------------------------------------------------------------------------------------



}
