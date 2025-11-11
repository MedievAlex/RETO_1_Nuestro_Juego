using UnityEngine;

public class Levitation : MonoBehaviour
{     
    // Not visible variables
    private float speed = 0.02f; // Movement speed
    private Vector3 pointA; // First position
    private Vector3 pointB; // Second position
    private Vector3 pointC; // Third position
    private bool towardsA = false; // Moving towards the first position (point A)
    private bool towardsB = false; // Moving towards the second position (point B)
    private bool towardsC = false; // Moving towards the third position (point C)
    private bool backToB = false; // Moving towards the fourth position (point D)

    // It runs once before the first Update it's executed
    void Start()
    {
        pointB = transform.position;
        SetPoints(pointB);
    }

    // Update is executed once per frame
    void Update()
    {
        if (towardsA) // Moving towards the first position (point A)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA, speed * Time.deltaTime);

            if (transform.position == pointA) // Changes direction
            {
                towardsA = false; // Stops moving towards A
                towardsB = true; // Starts moving towards B
            }
        }
        else if (towardsB || backToB) // Moving towards or back to the second position (point B)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB, speed * Time.deltaTime);

            if (transform.position == pointB && towardsB) // Changes direction towards the third position (point C)
            {
                towardsB = false; // Stops moving towards B
                towardsC = true; // Starts moving towards C

            }
            else if (transform.position == pointB && backToB) // Changes direction towards the first position (point A)
            {
                backToB = false; // Stops moving towards B
                towardsA = true; // Starts moving towards A
            }
        }
        else if (towardsC) // Moving towards the third position (point C)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointC, speed * Time.deltaTime);

            if (transform.position == pointC) // Changes direction
            {
                towardsC = false; // Stops moving towards C
                backToB = true; // Starts moving back to B
            }
        }
    }

    // Executed when a collision occurs
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Check that the collided object has the "Player" label
        {
            collision.transform.SetParent(transform); // Makes the object labeled "Player" a child of the platform, causing it to move along with it
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

    private void SetPoints(Vector3 pointB)
    {
        pointA.y = pointB.y + 0.05f;
        pointA.x = pointB.x;
        pointC.y = pointB.y - 0.05f;
        pointC.x = pointB.x;
                 
        towardsA = true;
    }
}