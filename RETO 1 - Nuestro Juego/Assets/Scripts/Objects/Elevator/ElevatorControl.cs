using UnityEngine;

public class ElevatorControl : MonoBehaviour
{
    // Visible variables
    public bool activated; // If the elevator starts activated or not
    public float speed = 2f; // Movement speed
    public int door = 3; // 3 = LeftDoor 4 = RightDoor
    public bool doorOpen; // If the choosed door it starts open


    // Not visible variables
    private Vector3 destinationPosition; // Destination
    private bool towardsPosition = false; // Moving towards the position

    // START runs once before the first Update it's executed
    void Start()
    {
        if (doorOpen)
        {
            transform.GetChild(door).GetComponent<Collider>().enabled = false;
        }
        else 
        {
            transform.GetChild(door).GetComponent<Collider>().enabled = true;
        }
    }

    // UPDATE is executed once per frame
    void Update()
    {
        if (towardsPosition) // Moving towards the position
        {
            transform.GetChild(door).GetComponent<Collider>().enabled = true; // Closes the door
            transform.position = Vector3.MoveTowards(transform.position, destinationPosition, speed * Time.deltaTime);
            
            if (transform.position == destinationPosition) 
            {
                towardsPosition = false; // Stops moving
                activated = false;
                transform.GetChild(door).GetComponent<Collider>().enabled = false; // Opens the door
            }
        } 
    }

    // Executed when a collision with a trigger is happening
    private void OnTriggerStay(Collider collider)
    {
        if(Input.GetKeyDown(KeyCode.E)){
            activated = true;
        }

        if (collider.gameObject.CompareTag("Player") && activated) 
        {
            collider.transform.SetParent(transform); // Makes the object labeled "Player" a child of the platform, causing it to move along with it
            towardsPosition = true; // Starts moving towards B
        }
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

    // Executed when a collision ends
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Check that the object that has stopped colliding has the "Player" tag
        {
            collision.transform.SetParent(null); // Removes the platform as the parent of the object labeled "Player"
        }
    }

    // Method to call the elevator
    public void moveOnCall(Vector3 destinationPosition, bool stateActive)
    {
        this.destinationPosition = destinationPosition;
        activated = stateActive;
        towardsPosition = stateActive;
    }
}
