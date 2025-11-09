using UnityEngine;

public class Lever : MonoBehaviour
{
    // Visible variables
    [Header("Manager")] // Makes a header on the public variables
    public GameManager gameManager;

    [Header("State")] // Makes a header on the public variables
    public bool stateActive; // If the lever is active or not

    [Header("Sprites")] // Makes a header on the public variables
    public Material activeSprite;
    public Material inactiveSprite;

    // Not visible variables
    private AudioController audioController;
    private bool stateActivable; // If the ladder is actibable or not

    // START runs once before the first Update it's executed
    void Start()
    {
        Debug.Log("[Lever] Searching for GameManager.");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // Finds the AudioController of the Scene

        Debug.Log("[Lever] Setting Audio Controller.");
        audioController = gameManager.GetAudioController();
    }

    // UPDATE is executed once per frame
    void Update()
    {
        if (stateActivable && Input.GetKeyDown(KeyCode.E)) // Changes lever's state
        {
            audioController.LeverAudio(GetComponent<AudioSource>());

            stateActive = !stateActive;
            Debug.Log("[Lever] Changed state to " + stateActive + ".");

            /*
            if (!stateActive) // If the lever was activated, it deactivates it
            {
                stateActive = true;
            }
            else // If the lever was deactivated, it activates it
            {
                stateActive = false;
            }
            */
        }
        changeSprite();
    }

    private void changeSprite()
    {
        if (stateActive) // Changes the sprite
        {
            transform.GetComponent<Renderer>().material = activeSprite;
        }
        else
        {
            transform.GetComponent<Renderer>().material = inactiveSprite;
        }
    }

    // Executed when a collision with a trigger occurs
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player")) // Check that the collided object has the "Player" label
        {
            stateActivable = true;
        }
    }

    // Executed when a collision with a trigger ends
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player")) // Check that the collided object has the "Player" label
        {
            stateActivable = false;
        }
    }
}
