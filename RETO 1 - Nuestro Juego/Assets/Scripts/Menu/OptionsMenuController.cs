using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenuController : MonoBehaviour
{
    // Visible variables
    [SerializeField] private GameObject Canvas;

    [Header("Buttons")] // Makes a header on the public variables
    public Button backButton;

    [Header("Volume")] // Makes a header on the public variables
    public Slider volumeSlider;
    public TextMeshProUGUI volumePercentText;

    // Not visible variables
    private AudioController audioController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        setActive(false);

        audioController = GameObject.Find("AudioController").GetComponent<AudioController>();

        float savedVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        volumeSlider.value = savedVolume;
        UpdateVolumeText(savedVolume);

        volumeSlider.onValueChanged.AddListener(OnVolumeChanged); // When clicking Volume Slider changes the volume value

        backButton.onClick.AddListener(back); // When clicking Back button goes to the previous menu

        AudioListener.volume = savedVolume;
    }

    private void back()
    {
        PlayerPrefs.Save();

        setActive(false);
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

    public void setActive(bool active)
    {
        if (Canvas != null)
        {
            Canvas.SetActive(active);
        }
    }

    void OnDestroy()
    {
        PlayerPrefs.Save();
    }
}