using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

/** [ AUTOMATIC MOBILE PLATFORM BETWEEN A-B-C-D ]
- The object moves constantly from the entered points A, B, C and D
- The order is sequential in a loop
*/
public class MobileAutomaticPlatformLoopOf4 : MonoBehaviour
{
    // Visible variables
    public Vector3 pointA; // First position
    public Vector3 pointB; // Second position
    public Vector3 pointC; // Third position
    public Vector3 pointD; // Fourth position
    public float speed = 2f; // Movement speed

    // Not visible variables
    private bool towardsA = true; // Moving towards the first position (point A)
    private bool towardsB = false; // Moving towards the second position (point B)
    private bool towardsC = false; // Moving towards the third position (point C)
    private bool towardsD = false; // Moving towards the fourth position (point D)

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
                towardsB = true; // Starts moving towards B
            }
        }
        else if (towardsB) // Moving towards the second position (point B)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB, speed * Time.deltaTime);
            
            if (transform.position == pointB && towardsB) // Changes direction
            {
                towardsB = false; // Stops moving towards B
                towardsC = true; // Starts moving towards C
            } 
        }
        else if (towardsC) // Moving towards the third position (point C)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointC, speed * Time.deltaTime);
           
            if (transform.position == pointC) // Changes direction
            {
                towardsC = false; // Stops moving towards C
                towardsD = true; // Starts moving towards D 
            }
        }
        else if (towardsD) // Moving towards the fourth position (point D)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointD, speed * Time.deltaTime);
           
            if (transform.position == pointD) // Changes direction
            {
                towardsD = false; // Stops moving towards D
                towardsA = true; // Starts moving towards A
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
}