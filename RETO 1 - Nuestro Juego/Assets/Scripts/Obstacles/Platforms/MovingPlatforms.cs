using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    // Visible variables
    public AudioClip audioClip;

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
        audioController.verifyedOShotAudio(audioClip, 1f, true);
    }
}
