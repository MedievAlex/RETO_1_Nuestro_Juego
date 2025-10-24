using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Botones")]
    public Button playButton;
    public Button optionsButton;
    public Button exitButton;

    [Header("Referencias")]
    public string levelScene = "Level-1";
    public string optionsMenuScene = "OptionsMenu";

    void Start()
    {
        playButton.onClick.AddListener(() => {
            SceneManager.LoadScene(levelScene, LoadSceneMode.Single);
            Destroy(GameObject.Find("MainCamera").GetComponent<MainCameraController>()); // Destroys the main camera
        });

        optionsButton.onClick.AddListener(() => {
            SceneManager.LoadScene(optionsMenuScene, LoadSceneMode.Single);
        });

        exitButton.onClick.AddListener(() => {
            Debug.Log("Saliendo del juego...");
            Application.Quit();
        });
    }
}