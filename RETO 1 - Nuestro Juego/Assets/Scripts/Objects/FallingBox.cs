using UnityEngine;
using UnityEngine.Audio;

/** [ STONE OBJECT FALLS AND DISAPPEARS ]
- Spawns and it falls. Once touching the floor dissapears.
*/
public class FallingBox : MonoBehaviour
{
    // Not visible variables  
    private AudioController audioController;
    private bool ground = false;

    // It runs once before the first Update it's executed
    void Start()
    {
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>(); // Finds the AudioController of the Scene
    }

    // Update is executed once per frame
    void Update()
    {
        
    }

    // Executed when a collision occurs
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player")) // Check that the collided object has the "Ground" or "Player" label
        {           
            audioController.fallBoxAudio(GetComponent<AudioSource>());       
        }
    }
}