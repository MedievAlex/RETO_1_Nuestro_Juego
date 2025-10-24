using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    [Header("Elementos de Volumen")]
    public Slider volumeSlider;
    public TextMeshProUGUI volumePercentText;
    public Button backButton;

    [Header("Referencias")]
    public string mainMenuScene = "MainMenu";

    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        volumeSlider.value = savedVolume;
        UpdateVolumeText(savedVolume);

        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);

        backButton.onClick.AddListener(() =>
        {
            PlayerPrefs.Save();

            SceneManager.LoadScene(mainMenuScene, LoadSceneMode.Single);
        });

        AudioListener.volume = savedVolume;
    }

    void OnVolumeChanged(float volume)
    {
        AudioListener.volume = volume;

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.SetVolume(volume);
        }

        UpdateVolumeText(volume);
        PlayerPrefs.SetFloat("MasterVolume", volume);
        PlayerPrefs.Save();
    }

    void UpdateVolumeText(float volume)
    {
        int percent = Mathf.RoundToInt(volume * 100);
        volumePercentText.text = percent + "%";
    }

    void OnDestroy()
    {
        PlayerPrefs.Save();
    }
}