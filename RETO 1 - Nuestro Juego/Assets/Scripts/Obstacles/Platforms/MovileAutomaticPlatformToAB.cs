using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

/** [ AUTOMATIC MOBILE PLATFORM TO A-B ]
- The object moves by activation from the entered points A, B, C, D and E
*/
public class MobileAutomaticPlatformToAB : MonoBehaviour
{
    // Visible variables
    public PlayerControl2D targetPlayer;
    public Vector3 pointA; // First position
    public Vector3 pointB; // Second position
    public float speed = 2f; // Movement speed

    // Not visible variables
    private bool inGoal, inMovement; // If the platform is in the goal or in movement
    private bool towardsA = true; // Moving towards the first position (point A)
    private bool towardsB = false; // Moving towards the second position (point B)

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
            inMovement = true;

            if (transform.position == pointA) // Changes direction
            {
                towardsA = false; // Stops moving towards A
                towardsB = true; // Starts moving towards B
            }
        }
        else if (towardsB) // Moving towards the second position (point B)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB, speed * Time.deltaTime);
            
            if (transform.position == pointB && towardsB) // Changes direction
            {
                towardsB = false; // Stops moving towards B
                inMovement = false;
                inGoal = true;
            } 
        }       
    }

    // Executed when a collision occurs
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Check that the collided object has the "Player" label
        {                       
            collision.transform.SetParent(transform); // Makes the object labeled "Player" a child of the platform, causing it to move along with it
            if(!inGoal && !inMovement)
            {
                towardsA = true; // Starts moving towards A
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