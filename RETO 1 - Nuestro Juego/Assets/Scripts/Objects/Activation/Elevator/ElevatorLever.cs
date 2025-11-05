using UnityEngine;

public class ElevatorLever : MonoBehaviour
{
    // Visible variables
    public Vector3 destinationPosition; // Called destination
    public bool stateActive; // If the lever is active or not
    public Material activeSprite;
    public Material inactiveSprite;

    // Not visible variables
    private AudioController audioController;
    private ElevatorControl elevator; // Referenced elevator
    private bool stateActivable; // If the ladder is actibable or not

    // START runs once before the first Update it's executed
    void Start()
    {
        elevator = transform.parent.gameObject.GetComponent<ElevatorControl>(); // Gets the parent object
        elevator.moveOnCall(destinationPosition, stateActive);
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>(); // Finds the AudioController of the Scene
    }

    // UPDATE is executed once per frame
    void Update()
    {
       if (stateActivable && Input.GetKeyDown(KeyCode.E)) // Changes lever's state
       {
            audioController.leverAudio(GetComponent<AudioSource>());

            if (!stateActive) // If the lever was activated, it deactivates it
           {
                stateActive = true;
                elevator.moveOnCall(destinationPosition, stateActive);
           } 
           else // If the lever was deactivated, it activates it
           {
               stateActive = false;
           }
       }

       if (elevator.transform.position == destinationPosition) // When the elevator finishes moving it goes back to desactivated mode
       {
           stateActive = false;
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
