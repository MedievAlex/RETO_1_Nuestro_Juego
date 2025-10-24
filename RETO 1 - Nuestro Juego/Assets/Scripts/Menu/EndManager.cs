using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndManager : MonoBehaviour
{
    [Header("Botones")]
    public Button menuButton;

    [Header("Referencias")]
    public string MainMenuScene = "MainMenu";

    void Start()
    {
        menuButton.onClick.AddListener(() => {
            SceneManager.LoadScene(MainMenuScene, LoadSceneMode.Single);
        });
    }
}