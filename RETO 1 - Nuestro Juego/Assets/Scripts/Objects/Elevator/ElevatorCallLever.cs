using UnityEngine;
using UnityEngine.Audio;

public class ElevatorCallLever : MonoBehaviour
{
    // Visible variables
    public ElevatorControl elevator; // Referenced elevator
    public Vector3 destinationPosition; // Called destination
    public bool stateActive; // If the lever is active or not
    public AudioClip audioClip;

    // Not visible variables
    private bool stateActivable; // If the ladder is actibable or not
    private AudioController audioController;

    // START runs once before the first Update it's executed
    void Start()
    {
        elevator.moveOnCall(destinationPosition, stateActive);
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>(); // Finds the AudioController of the Scene
    }

    // UPDATE is executed once per frame
    void Update()
    {
        if (stateActivable && Input.GetKeyDown(KeyCode.E)) // Changes lever's state
        {
            audioController.oneShotAudio(audioClip, 1f, true);

            if (!stateActive) // If the lever was deactivated, it activates it
            {
                stateActive = true;
                elevator.moveOnCall(destinationPosition, stateActive);
            }
            else // If the lever was activated, it deactivates it
            {
                stateActive = false;
            }
        }

        if (elevator.transform.position == destinationPosition)  // When the elevator finishes moving it goes back to desactivated mode
        {
            stateActive = false;
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

    // Getter to gestion more than one
    public bool getStateActivable()
    {
        return stateActivable;
    }
}
