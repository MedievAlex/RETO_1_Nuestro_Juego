using UnityEngine;

public class LevelExitElevator : MonoBehaviour
{
    // Visible variables
    public float speed = 2f; // Movement speed
    public Vector3 position; // Second position
    public int door = 5; // 3 = LeftDoor 5 = RightDoor
    public bool doorOpen; // 3 = LeftDoor 5 = RightDoor

    // Not visible variables
    private bool inPosition = false; // Checks if it's in position
    private bool towardsPosition = false; // Moving towards the second position (point B)

    // START runs once before the first Update it's executed
    void Start()
    {
        if (doorOpen) // It starts with the door open
        {
            transform.GetChild(door).GetComponent<Collider>().enabled = false; 
        }    
    }

    // UPDATE is executed once per frame
    void Update()
    {
        if (towardsPosition) // Moving towards the position
        {
            transform.position = Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);

            if (transform.position == position) 
            {
                towardsPosition = false; // Stops moving             
                transform.GetChild(door).GetComponent<Collider>().enabled = false;
            }
        } 
    }

    // Executed when a collision occurs
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player")) // Check that the collided object has the "Player" label
        {
            if (transform.GetChild(4).GetComponent<Collider>().gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
            {
                collider.transform.SetParent(transform); // Makes the object labeled "Player" a child of the platform, causing it to move along with it
                towardsPosition = true; // Starts moving towards B
                transform.GetChild(door).GetComponent<Collider>().enabled = true;
            }
        }
    }

    // Executed while a collision occurs
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && transform.position != position) // Check that the collided object has the "Player" label
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
}
