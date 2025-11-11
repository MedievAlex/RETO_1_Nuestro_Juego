using System;
using UnityEngine;
using UnityEngine.Audio;

public class ElevatorControl : MonoBehaviour
{
    // Visible variables
    [Header("Manager")] // Makes a header on the public variables
    public GameManager gameManager;  
    public int door; // 3 = LeftDoor 4 = RightDoor
    public bool doorStartOpen; // If the choosed door it starts open 

    // Not visible variables
    private AudioSource audioSource;
    private bool activated; // If the elevator starts activated or not
    private float speed = 3f; // Movement speed
    private Vector3 destinationPosition; // Destination
    private bool towardsPosition = false; // Moving towards the position    

    // START runs once before the first Update it's executed
    void Start()
    {
        Debug.Log("[Elevator] Searching for GameManager.");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // Finds the AudioController of the Scene
        
        audioSource = GetComponent<AudioSource>();

        StartSettings();
    }

    // UPDATE is executed once per frame
    void Update()
    {
        if (towardsPosition) // Moving towards the position
        {
            gameManager.ElevatorAudio(audioSource, 1, true);

            openDoor(false); // Closes the door
            transform.position = Vector3.MoveTowards(transform.position, destinationPosition, speed * Time.deltaTime);

            if (transform.position == destinationPosition)
            {
                gameManager.ElevatorAudio(audioSource, 1, false);
                gameManager.ElevatorAudio(audioSource, 2, true);
                towardsPosition = false; // Stops moving
                activated = false;
                openDoor(true); // Opens the door
            }
        }
    }

    // Sets the values for the start
    public void StartSettings()
    {
        if(door == 3)
        {
            Debug.Log("[Elevator] Left Door start open " + doorStartOpen + ".");
        }
        else if(door == 4)
        {
            Debug.Log("[Elevator] Right Door start open " + doorStartOpen + ".");
        }
        
        openDoor(doorStartOpen);
    }

    // Executed while a collision is happening
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && transform.position != destinationPosition) // Check that the collided object has the "Player" label
        {
            collision.gameObject.GetComponent<Rigidbody>().linearVelocity = Vector3.zero; // Stop it from moving
            collision.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero; // Reset the physical rotation
        }
    }

    // Executed when a collision with a trigger is happening
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            gameManager.AbilityGestion("JUMP", false);

            if (activated)
            {
                collider.transform.SetParent(transform); // Makes the object labeled "Player" a child of the platform, causing it to move along with it
                towardsPosition = true; // Starts moving
            }
        }
    }

    // Executed when a collision with a trigger ends
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player")) // Check that the object that has stopped colliding has the "Player" tag
        {
            gameManager.AbilityGestion("JUMP", true);
            collider.transform.SetParent(null); // Removes the platform as the parent of the object labeled "Player"
        }
    }

    // Methods to call and move the elevator
    public void openDoor(bool doorOpen)
    {
        Debug.Log("[Elevator] Door Open " + doorOpen + ".");
        if (doorOpen)
        {
            transform.GetChild(door).GetComponent<Collider>().enabled = false; // Disables de collinder opening the door
        }
        else
        {
            transform.GetChild(door).GetComponent<Collider>().enabled = true; // Enables de collinder closing the door
        }
    }

    // Calls and starts moving the elevator
    public void moveOnCall(Vector3 destinationPosition, bool stateActive)
    {
        this.destinationPosition = destinationPosition;
        activated = stateActive;
        towardsPosition = stateActive;
    }
}
