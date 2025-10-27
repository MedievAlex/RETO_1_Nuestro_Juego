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
        ApplyVolumeOnStart();

        playButton.onClick.AddListener(() => {
            SceneManager.LoadScene(levelScene, LoadSceneMode.Single);
        });

        optionsButton.onClick.AddListener(() => {
            SceneManager.LoadScene(optionsMenuScene, LoadSceneMode.Single);
        });

        exitButton.onClick.AddListener(() => {
            Application.Quit();
        });
    }

    void ApplyVolumeOnStart()
    {
        float savedVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        AudioListener.volume = savedVolume;

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.SetVolume(savedVolume);
        }
    }
}