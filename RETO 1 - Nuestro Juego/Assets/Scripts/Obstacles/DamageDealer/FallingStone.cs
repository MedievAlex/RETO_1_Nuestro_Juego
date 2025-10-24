using UnityEngine;
using UnityEngine.Audio;

/** [ STONE OBJECT FALLS AND DISAPPEARS ]
- Spawns and it falls. Once touching the floor dissapears.
*/
public class FallingStone : MonoBehaviour
{
    // Visible variables
    public AudioClip audioClip;

    // Not visible variables
    private bool broken = false; // Indicates whether the object has touched the ground
    private AudioController audioController;

    // It runs once before the first Update it's executed
    void Start()
    {
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>(); // Finds the AudioController of the Scene
    }

    // Update is executed once per frame
    void Update()
    {
        if (broken) // When it touches the ground
        {
            Destroy(gameObject); // It's destoyed
        }
    }

    // Executed when a collision occurs
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player")) // Check that the collided object has the "Ground" or "Player" label
        {
            audioController.oneShotAudio(audioClip, 0.2f, true);
            broken = true;
        }
    }
}