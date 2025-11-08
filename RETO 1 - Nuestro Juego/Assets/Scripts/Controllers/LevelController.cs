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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentLevel = 0;   
    }

    // Loads the fist level
    public void GameStart()
    {
        LoadLevel(1);
    }

    // Loads the next level
    public void NextLevel()
    {
        currentLevel++;
        SceneManager.LoadScene(Level(), LoadSceneMode.Single);
        SetSpecificBackground(currentLevel);
    }

    // Restart the Level count and loads the first one
    public void RestartGame()
    {
        currentLevel = 1;
        SceneManager.LoadScene(Level(), LoadSceneMode.Single);
        SetSpecificBackground(currentLevel);
    }

    // Makes the name of the Level
    private string Level()
    {
        return "Level-" + currentLevel;
    }

    // Gets the number of the level
    public int GetLevel()
    {
        return currentLevel;
    }

    // Sets the background for each level
    public void SetSpecificBackground(int level)
    {
        gameManager.SetSpecificBackground(level);
    }

    // Loads an specific Level
    public void LoadLevel(int level)
    {
        switch (level)
        {
            case 1:
                currentLevel = 1;
                SceneManager.LoadScene("Level-1", LoadSceneMode.Single);
                SetSpecificBackground(currentLevel);
                break;

            case 2:
                currentLevel = 2;
                SceneManager.LoadScene("Level-2", LoadSceneMode.Single);
                SetSpecificBackground(currentLevel);
                break;

            case 3:
                currentLevel = 3;
                SceneManager.LoadScene("Level-3", LoadSceneMode.Single);
                SetSpecificBackground(currentLevel);
                break;
        }
    }

}
