using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Not visible variables
    private Player2D targetPlayer = null;
    private AudioController audioController;

    // It runs once before the first Update it's executed
    void Start()
    {
        targetPlayer = GameObject.Find("Player2D").GetComponent<Player2D>(); // Finds the GameObject of the class PlayerControl2D
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>(); // Finds the AudioController of the Scene
    }

    // Update is executed once per frame
    void Update()
    {

    }

    // Executed when a collision with a trigger occurs
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player")) // Check that the collided object has the "Player" label
        {
            audioController.CheckPointAudio(GetComponent<AudioSource>());
            targetPlayer.SetRespawn(collider.transform.position);
            Destroy(GetComponent<Collider>()); // Destroys the checkpoint
        }
    }
}