using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    // Visible variables
    [Header("Manager")] // Makes a header on the public variables
    public GameManager gameManager;

    // Not visible variables
    private int currentLevel;

    // Loads the fist level
    public void GameStart()
    {
        Debug.Log("[LevelController] Game Start.");
        LoadLevel(1);
    }

    // Loads the next level
    public void NextLevel()
    {
        currentLevel++;
        Debug.Log("[LevelController] Loading next Level: Level-" + currentLevel + ".");
        SceneManager.LoadScene(Level(), LoadSceneMode.Single);
        SetSpecificBackground();
    }

    // Restart the Level count and loads the first one
    public void RestartGame()
    {
        currentLevel = 1;
        Debug.Log("[LevelController] Restarting at Level-" + currentLevel + ".");
        SceneManager.LoadScene(Level(), LoadSceneMode.Single);
        SetSpecificBackground();
    }

    // Main menu
    public void MainMenu()
    {
        LoadLevel(0);
    }

    // Makes the name of the Level
    private string Level()
    {
        return "Level-" + currentLevel;
    }

    // Gets the number of the level
    public int GetLevel()
    {
        Debug.Log("[LevelController] Current Level: " + currentLevel + ".");
        return currentLevel;
    }

    // Sets the background for each level
    public void SetSpecificBackground()
    {
        if (currentLevel > 0)
        {
            Debug.Log("[LevelController] Setting specific Background for Level-" + currentLevel + ".");
        }
        else
        {
            Debug.Log("[LevelController] Setting specific Background for Main Menu.");
        }
        gameManager.SetSpecificBackground(currentLevel);
    }

    // Loads an specific Level
    public void LoadLevel(int level)
    {
        switch (level)
        {
            case 0:
                currentLevel = 0;
                Debug.Log("[LevelController]: Loading Main Menu.");
                SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
                SetSpecificBackground();
                break;
            
            case 1:
                currentLevel = 1;
                Debug.Log("[LevelController]: Loading Level-" + currentLevel + ".");
                SceneManager.LoadScene("Level-1", LoadSceneMode.Single);
                SetSpecificBackground();
                break;

            case 2:
                currentLevel = 2;
                Debug.Log("[LevelController]: Loading Level-" + currentLevel + ".");
                SceneManager.LoadScene("Level-2", LoadSceneMode.Single);
                SetSpecificBackground();
                break;

            case 3:
                currentLevel = 3;
                Debug.Log("[LevelController]: Loading Level-" + currentLevel + ".");
                SceneManager.LoadScene("Level-3", LoadSceneMode.Single);
                SetSpecificBackground();
                break;
        }
    }
}
