using System.Drawing;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

/** [ AUTOMATIC MOBILE PLATFORM TO A-B-C ]
- The object moves by activation from the entered points A, B, and C
*/
public class MobileAutomaticPlatformTo3 : MonoBehaviour
{
    // Visible variables
    public Vector3 pointA; // First position
    public Vector3 pointB; // Second position
    public Vector3 pointC; // Third position
    public float speed = 0.05f; // Movement speed

    // Not visible variables 
    private bool towardsA = false; // Moving towards the first position (point A)
    private bool towardsB = true; // Moving towards the second position (point B)
    private bool towardsC = false; // Moving towards the third position (point C)
    private bool backToB = false; // Moving towards the fourth position (point D)
    private bool inMovement; // If the platform is in movement
    private float resetTime = 5f;
    private float timePassed;

    // It runs once before the first Update it's executed
    void Start()
    {

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
                inMovement = false;
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
                inMovement = false;
            }
        }

        if (transform.position != pointA ^ transform.position != pointC) // ^ = XOR
        {
            timePassed += Time.deltaTime; // Calculates the time
            if (timePassed > resetTime) // Sctarts moving again
            {
                if (transform.position == pointA)
                {
                    towardsB = true; // Starts moving towards B
                }
                else if (transform.position == pointC)
                {
                    backToB = true; // Starts moving back to B
                }
                timePassed = 0f;
            }  
        }
    }
    
    // Executed when a collision occurs
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Check that the collided object has the "Player" label
        {
            collision.transform.SetParent(transform); // Makes the object labeled "Player" a child of the platform, causing it to move along with it
            if (!inMovement)
            {
                if (transform.position == pointA)
                {
                    towardsB = true; // Starts moving towards B
                }
                else if (transform.position == pointC)
                {
                    backToB = true; // Starts moving back to B
                }
            }
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