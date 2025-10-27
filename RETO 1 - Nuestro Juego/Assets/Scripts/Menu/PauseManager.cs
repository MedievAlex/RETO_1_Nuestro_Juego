using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PauseManager : MonoBehaviour
{
    [Header("Paneles UI")]
    public GameObject backgroundPanel;
    public GameObject pausePanel;
    public GameObject optionsPanel;

    [Header("Elementos de Volumen")]
    public Slider volumeSlider;
    public TextMeshProUGUI volumePercentText;

    [Header("Referencias")]
    public string menuScene = "MainMenu";

    private bool gameStopped = false;

    void Start()
    {
        backgroundPanel.SetActive(false);
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);

        SetupButtonsManually();
        SetupVolumeSystem();
    }

    void SetupButtonsManually()
    {
        Button[] allButtons = GetComponentsInChildren<Button>(true);

        foreach (Button button in allButtons)
        {
            if (button.name.Contains("Resume"))
            {
                button.onClick.AddListener(ResumeGame);
            }
            else if (button.name.Contains("Options"))
            {
                button.onClick.AddListener(ShowOptions);
            }
            else if (button.name.Contains("Menu"))
            {
                button.onClick.AddListener(GoToMenu);
            }
            else if (button.name.Contains("Back"))
            {
                button.onClick.AddListener(BackFromOptions);
            }

            button.interactable = true;
            Image btnImage = button.GetComponent<Image>();
            if (btnImage != null) btnImage.raycastTarget = true;
        }
    }

    void SetupVolumeSystem()
    {
        if (volumeSlider != null)
        {
            float savedVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
            volumeSlider.value = savedVolume;

            UpdateVolumeText(savedVolume);
            ApplyVolumeImmediately(savedVolume);

            volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        }
    }

    void OnVolumeChanged(float volume)
    {
        ApplyVolumeImmediately(volume);
        UpdateVolumeText(volume);
        PlayerPrefs.SetFloat("MasterVolume", volume);
        PlayerPrefs.Save();
    }

    void UpdateVolumeText(float volume)
    {
        if (volumePercentText != null)
        {
            int percent = Mathf.RoundToInt(volume * 100);
            volumePercentText.text = percent + "%";
        }
    }

    void ApplyVolumeImmediately(float volume)
    {
        AudioListener.volume = volume;

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.SetVolume(volume);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        gameStopped = !gameStopped;
        if (gameStopped) PauseGame();
        else ResumeGame();
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        backgroundPanel.SetActive(true);
        pausePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        backgroundPanel.SetActive(false);
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void ShowOptions()
    {
        pausePanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    void BackFromOptions()
    {
        optionsPanel.SetActive(false);
        pausePanel.SetActive(true);
    }

    void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuScene);
    }

    void OnDestroy()
    {
        PlayerPrefs.Save();
    }
}