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

    [Header("Backgrounds")] // Makes a header on the public variables
    public Sprite menuBackground;
    public Sprite firstLevelBackground;
    public Sprite secondLevelBackground;
    public Sprite thirdLevelBackground;

    // Not visible variables
    private MenuController menuController;
    private AudioController audioController;
    private Image backgroundImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menuController = transform.parent.GetComponentInParent<MenuController>(); // Gets the Menu Controller
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>();

        backgroundImage = transform.GetChild(0).transform.GetChild(0).transform.GetComponent<Image>();

        SetActive(false);

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

    // Sets the background for each level
    public void SetSpecificBackground(int level)
    {
        switch (level)
        {
            case 0:
                backgroundImage.preserveAspect = false;
                backgroundImage.sprite = firstLevelBackground;  
                break;

            case 1:
                backgroundImage.preserveAspect = true;
                backgroundImage.sprite = firstLevelBackground;
                break;

            case 2:
                backgroundImage.preserveAspect = true;
                backgroundImage.sprite = secondLevelBackground;
                break;

            case 3:
                backgroundImage.preserveAspect = true;
                backgroundImage.sprite = thirdLevelBackground;
                break;
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