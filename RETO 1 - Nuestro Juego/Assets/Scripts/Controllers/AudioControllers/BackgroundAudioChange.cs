using UnityEngine;
using UnityEngine.InputSystem.XR;

public class BackgroundAudioChange : MonoBehaviour
{
    // Visible variables
    public string clip;

    // Not visible variables
    private AudioController audioController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>(); // Finds the AudioController of the Scene
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            audioController.backgroundAudio(clip, true);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            audioController.backgroundAudio(clip, false);
        }
    }
}
