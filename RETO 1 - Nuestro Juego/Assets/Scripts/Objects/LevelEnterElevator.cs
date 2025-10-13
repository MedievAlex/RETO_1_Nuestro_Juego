using UnityEngine;

public class LevelEnterElevator : MonoBehaviour
{
    // Visible variables
    public Vector3 position; // Second position
    public float speed = 2f; // Movement speed

    // Not visible variables
    private bool towardsPosition = false; // Moving towards the second position (point B)

    // START runs once before the first Update it's executed
    void Start()
    {
        
    }

    // UPDATE is executed once per frame
    void Update()
    {
        if (towardsPosition) // Moving towards the second position (point B)
        {
            transform.position = Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);

            if (transform.position == position) // Changes direction
            {
                towardsPosition = false; // Stops moving towards B
            }
        }

    }

    // Executed when a collision occurs
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Check that the collided object has the "Player" label
        {
            collision.transform.SetParent(transform); // Makes the object labeled "Player" a child of the platform, causing it to move along with it
            towardsPosition = true; // Starts moving towards B
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
