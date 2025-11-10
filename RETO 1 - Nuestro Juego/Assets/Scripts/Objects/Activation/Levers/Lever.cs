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
    private AudioSource audioSource;
    private bool stateActivable; // If the ladder is actibable or not

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("[Lever] Searching for GameManager.");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // Finds the AudioController of the Sceneent 

        audioSource = GetComponent<AudioSource>();
    }

    // UPDATE is executed once per frame
    void Update()
    {
        if (stateActivable && Input.GetKeyDown(KeyCode.E)) // Changes lever's state
        {
            gameManager.LeverAudio(audioSource);

            stateActive = !stateActive;
            Debug.Log("[Lever] Changed state to " + stateActive + ".");
        }
        changeSprite();
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

    // Sprite manager
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

    // Get State
    public bool GetActivable()
    {
        return stateActivable;
    }

    // Get State
    public bool GetState()
    {
        return stateActive;
    }

    // Set State
    public void SetState(bool state)
    {
        stateActive = state;
    }
}
