using UnityEngine;

/** [ Stalactite FALLS AND DISAPPEARS ]
- It falls when the player gets close. Once touching the floor dissapears.
*/
public class Stalactite : MonoBehaviour
{
    // Not visible variables
    private AudioController audioController;
    private Rigidbody rb; // Referencia al Rigidbody
    private bool broken = false; // Indicates whether the object has touched the ground

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
        rb.useGravity = false;
    }

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
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player")) // Check that the collided object has the "Player" label
        {
            audioController.RockBreakAudio(GetComponent<AudioSource>());
            rb.useGravity = true;
        }
    }

    // Executed when a collision occurs
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Platform")) // Check that the collided object has the "Ground" or "Player" label
        {
            broken = true;
        }
    }
}
