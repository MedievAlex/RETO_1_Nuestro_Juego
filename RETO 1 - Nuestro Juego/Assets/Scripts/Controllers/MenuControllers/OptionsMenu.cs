using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    // Visible variables
    [SerializeField] private GameObject Canvas;

    [Header("Buttons")] // Makes a header on the public variables
    public Button backButton;

    [Header("Volume")] // Makes a header on the public variables
    public Slider volumeSlider;
    public TextMeshProUGUI volumePercentText;

    // Not visible variables
    private MenuController menuController;
    private AudioController audioController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menuController = transform.parent.GetComponentInParent<MenuController>(); // Gets the Menu Controller

        SetActive(false);

        audioController = GameObject.Find("AudioController").GetComponent<AudioController>();

        float savedVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        volumeSlider.value = savedVolume;
        UpdateVolumeText(savedVolume);

        volumeSlider.onValueChanged.AddListener(OnVolumeChanged); // When clicking Volume Slider changes the volume value
        backButton.onClick.AddListener(CloseMenu); // When clicking Back button goes to the previous menu

        AudioListener.volume = savedVolume;
    }

    // Open or close the menu
    public void SetActive(bool active)
    {
        if (Canvas != null)
        {
            Canvas.SetActive(active);
        }
    }

    // Closes the Menu
    private void CloseMenu()
    {
        PlayerPrefs.Save();

        SetActive(false);
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