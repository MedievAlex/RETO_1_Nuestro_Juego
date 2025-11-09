using UnityEngine;

public class BackgroundAudioChange : MonoBehaviour
{
    // Visible variables
    [Header("Manager")] // Makes a header on the public variables
    public GameManager gameManager;

    [Header("Background Audio")] // Makes a header on the public variables
    public string clip;

    // Not visible variables
    private AudioController audioController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("[BackgroundAudio] Searching for GameManager.");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // Finds the AudioController of the Scene
        
        Debug.Log("[BackgroundAudio] Setting Audio Controller.");
        audioController = gameManager.GetAudioController();
    }

    // Plays or changes the background music
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("[BackgroundAudio] Playing " + clip + ".");
            audioController.BackgroundAudio(clip, true);
        }
    }

    // Stops the background music
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("[BackgroundAudio] Pausing " + clip + ".");
            audioController.BackgroundAudio(clip, false);
        }
    }
}