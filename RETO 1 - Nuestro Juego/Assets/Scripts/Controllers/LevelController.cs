using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    // Not visible variables
    private int currentLevel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentLevel = 1;   
    }

    // Loads the fist level
    public void GameStart()
    {
        SceneManager.LoadScene(Level(), LoadSceneMode.Single);
    }

    // Loads the next level
    public void NextLevel()
    {
        currentLevel++;
        SceneManager.LoadScene(Level(), LoadSceneMode.Single);
    }

    // Restart the Level count and loads the first one
    public void RestartGame()
    {
        currentLevel = 1;
        SceneManager.LoadScene(Level(), LoadSceneMode.Single);
    }

    // Makes the name of the Level
    private string Level()
    {
        return "Level-" + currentLevel;
    }

    // Loads an specific Level
    public void LoadLevel(int level)
    {
        switch (level)
        {
            case 1:
                SceneManager.LoadScene("Level-1", LoadSceneMode.Single);
                break;

            case 2:
                SceneManager.LoadScene("Level-2", LoadSceneMode.Single);
                break;

            case 3:
                SceneManager.LoadScene("Level-3", LoadSceneMode.Single);
                break;
        }
    }
}
