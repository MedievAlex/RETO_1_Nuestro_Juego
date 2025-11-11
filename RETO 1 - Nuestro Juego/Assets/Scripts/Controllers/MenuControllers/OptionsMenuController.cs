using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuController : MonoBehaviour
{
    // Visible variables
    [Header("Controller")] // Makes a header on the public variables
    public MenuController menuController;

    [Header("Canvas")] // Makes a header on the public variables
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
    private Image backgroundImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("[OptionsMenu] Getting Background.");
        backgroundImage = transform.GetChild(0).transform.GetChild(0).transform.GetComponent<Image>();

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
            Debug.Log("[OptionsMenu] Active " + active + ".");
            Canvas.SetActive(active);
        }
    }

    // Sets the background for each level
    public void SetSpecificBackground(int level)
    {
        switch (level)
        {
            case 0:
                Debug.Log("[OptionsMenu] Setting Background for Main Menu.");
                backgroundImage.preserveAspect = false;
                backgroundImage.sprite = menuBackground;
                break;

            case 1:
                Debug.Log("[OptionsMenu] Setting Background for Level-" + level + ".");
                backgroundImage.preserveAspect = true;
                backgroundImage.sprite = firstLevelBackground;
                break;

            case 2:
                Debug.Log("[OptionsMenu] Setting Background for Level-" + level + ".");
                backgroundImage.preserveAspect = true;
                backgroundImage.sprite = secondLevelBackground;
                break;

            case 3:
                Debug.Log("[OptionsMenu] Setting Background for Level-" + level + ".");
                backgroundImage.preserveAspect = true;
                backgroundImage.sprite = thirdLevelBackground;
                break;
        }
    }

    // Closes the Menu
    private void CloseMenu()
    {
        Debug.Log("[OptionsMenu] Saving changes.");
        PlayerPrefs.Save();

        SetActive(false);
    }

    // Updates the slider volume and the general volume
    private void OnVolumeChanged(float volume)
    {
        AudioListener.volume = volume;

        menuController.SetVolume(volume);

        UpdateVolumeText(volume);
        PlayerPrefs.SetFloat("MasterVolume", volume);
        PlayerPrefs.Save();
    }

    // Updates the percentage
    private void UpdateVolumeText(float volume)
    {
        int percent = Mathf.RoundToInt(volume * 100);
        volumePercentText.text = percent + "%";
    }

    private void OnDestroy()
    {
        PlayerPrefs.Save();
    }
}