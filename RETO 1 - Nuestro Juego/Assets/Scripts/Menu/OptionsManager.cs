using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    [Header("Buttons")] // Makes a header on the public variables
    public Button backButton;

    [Header("Volume")] // Makes a header on the public variables
    public Slider volumeSlider;
    public TextMeshProUGUI volumePercentText;

    [Header("References")] // Makes a header on the public variables
    public string backMenu;

    private AudioController audioController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>();

        float savedVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        volumeSlider.value = savedVolume;
        UpdateVolumeText(savedVolume);

        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);

        backButton.onClick.AddListener(() =>
        {
            PlayerPrefs.Save();

            SceneManager.LoadScene(backMenu, LoadSceneMode.Single);
        });

        AudioListener.volume = savedVolume;
    }

    void OnVolumeChanged(float volume)
    {
        AudioListener.volume = volume;

        if (audioController.getAudioController() != null)
        {
            audioController.getAudioController().SetVolume(volume);
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