using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

/** [ AUTOMATIC MOBILE PLATFORM 6 ]
- The object moves by activation from the entered points A, B, C, D, E and F
*/
public class MobileAutomaticPlatformTo6 : MonoBehaviour
{
    // Visible variables
    public PlayerControl2D targetPlayer;
    public Vector3 pointA; // 1ST position
    public Vector3 pointB; // 2ND position
    public Vector3 pointC; // 3RD position
    public Vector3 pointD; // 4TH position
    public Vector3 pointE; // 5TH position
    public Vector3 pointF; // 6TH position
    public float speed = 2f; // Movement speed

    // Not visible variables
    private bool inGoal, inMovement; // If the platform is in the goal or in movement
    private bool towardsA = true; // Moving towards the 1ST position (point A)
    private bool towardsB = false; // Moving towards the 2ND position (point B)
    private bool towardsC = false; // Moving towards the 3RD position (point C)
    private bool towardsD = false; // Moving towards the 4TH position (point D)
    private bool towardsE = false; // Moving towards the 5TH position (point E)
    private bool towardsF = false; // Moving towards the 6TH position (point F)
    private float spawnTime = 2f;
    private float timePassed;

    // It runs once before the first Update it's executed
    void Start()
    {
        pointA = transform.position;
    }

    // Update is executed once per frame
    void Update()
    {
        if (towardsA) // Moving towards the first position (point A)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB, speed * Time.deltaTime);

            if (transform.position == pointA) // Changes direction
            {
                towardsA = false; // Stops moving towards A
                towardsB = true; // Starts moving towards B
            }
        }
        else if (towardsB) // Moving towards the second position (point B)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointC, speed * Time.deltaTime);
            
            if (transform.position == pointB) // Changes direction
            {
                towardsB = false; // Stops moving towards B
                towardsC = true; // Starts moving towards C
            } 
        }
        else if (towardsC) // Moving towards the third position (point C)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointD, speed * Time.deltaTime);
           
            if (transform.position == pointC) // Changes direction
            {
                towardsC = false; // Stops moving towards C
                towardsD = true; // Starts moving towards D 
            }
        }
        else if (towardsD) // Moving towards the fourth position (point D)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointE, speed * Time.deltaTime);
           
            if (transform.position == pointD) // Changes direction
            {
                towardsD = false; // Stops moving towards D
                towardsA = true; // Starts moving towards A
            }     
        }
        else if (towardsE) // Moving towards the fifth position (point E)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointE, speed * Time.deltaTime);

            if (transform.position == pointE) // Changes direction
            {
                towardsE = false; // Stops moving towards D 
                inMovement = false;
                inGoal = true;
            }
        }
        else if (towardsF) // Moving towards the fifth position (point E)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointE, speed * Time.deltaTime);

            if (transform.position == pointF) // Changes direction
            {
                towardsF = false; // Stops moving towards D 
                inMovement = false;
                inGoal = true;
            }
        }

        if(transform.position != pointF || transform.position != pointA)
        {
            timePassed += Time.deltaTime; // Calculates the time
            if (timePassed > spawnTime) // Creates a new object and restarts the counter
            {
                if (transform.position == pointA)
                {

                }
                else if (transform.position == pointF)
                {

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