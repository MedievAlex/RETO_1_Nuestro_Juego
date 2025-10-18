using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

/** [ AUTOMATIC MOBILE PLATFORM 6 ]
- The object moves by activation from the entered points A, B, C, D, E and F
*/
public class MobileByActivationPlatformOf6 : MonoBehaviour
{
    // Visible variables
    public Vector3 pointA; // 1ST position
    public Vector3 pointB; // 2ND position
    public Vector3 pointC; // 3RD position
    public Vector3 pointD; // 4TH position
    public Vector3 pointE; // 5TH position
    public Vector3 pointF; // 6TH position
    public float speed = 2f; // Movement speed

    // Not visible variables
    private bool plyerOnTop = false; // If the platform is in movement
    private bool inMovement = false; // If the platform is in movement
    public bool frontwards = false;
    public bool backwards = false;
    private bool towardsA = false; // Moving towards the 1ST position (point A)
    private bool towardsB = false; // Moving towards the 2ND position (point B)
    private bool towardsC = false; // Moving towards the 3RD position (point C)
    private bool towardsD = false; // Moving towards the 4TH position (point D)
    private bool towardsE = false; // Moving towards the 5TH position (point E)
    private bool towardsF = false; // Moving towards the 6TH position (point F)
    private float resetTime = 5f;
    private float timePassed;

    // It runs once before the first Update it's executed
    void Start()
    {
        
    }

    // Update is executed once per frame
    void Update()
    {
        if (frontwards)
        {
            if (towardsB) // Moving towards point B
            {
                transform.position = Vector3.MoveTowards(transform.position, pointB, speed * Time.deltaTime);

                if (transform.position == pointB)
                {
                    towardsB = false; // Stops moving towards B
                    towardsC = true; // Starts moving towards C
                }
            }
            else if (towardsC) // Moving towards point C
            {
                transform.position = Vector3.MoveTowards(transform.position, pointC, speed * Time.deltaTime);

                if (transform.position == pointC)
                {
                    towardsC = false; // Stops moving towards C
                    towardsD = true; // Starts moving towards D 
                }
            }
            else if (towardsD) // Moving towards point D
            {
                transform.position = Vector3.MoveTowards(transform.position, pointD, speed * Time.deltaTime);

                if (transform.position == pointD)
                {
                    towardsD = false; // Stops moving towards D
                    towardsE = true; // Starts moving towards E
                }
            }
            else if (towardsE) // Moving towards point E
            {
                transform.position = Vector3.MoveTowards(transform.position, pointE, speed * Time.deltaTime);

                if (transform.position == pointE)
                {
                    towardsE = false; // Stops moving towards E 
                    towardsF = true; // Stops moving towards F 
                }
            }
            else if (towardsF) // Moving towards point F
            {
                transform.position = Vector3.MoveTowards(transform.position, pointF, speed * Time.deltaTime);

                if (transform.position == pointF)
                {
                    towardsF = false; // Stops moving towards F 
                    frontwards = false;
                    inMovement = false;
                }
            }
        }
        else if(backwards)
        {
            if (towardsE) // Moving towards point E
            {
                transform.position = Vector3.MoveTowards(transform.position, pointE, speed * Time.deltaTime);

                if (transform.position == pointE)
                {
                    towardsE = false; // Stops moving towards E
                    towardsD = true; // Starts moving towards D
                }
            }
            else if (towardsD) // Moving towards point D
            {
                transform.position = Vector3.MoveTowards(transform.position, pointD, speed * Time.deltaTime);

                if (transform.position == pointD)
                {
                    towardsD = false; // Stops moving towards D
                    towardsC = true; // Starts moving towards C
                }
            }
            else if (towardsC) // Moving towards point C
            {
                transform.position = Vector3.MoveTowards(transform.position, pointC, speed * Time.deltaTime);

                if (transform.position == pointC)
                {
                    towardsC = false; // Stops moving towards C
                    towardsB = true; // Starts moving towards B 
                }
            }
            else if (towardsB) // Moving towards point B
            {
                transform.position = Vector3.MoveTowards(transform.position, pointB, speed * Time.deltaTime);

                if (transform.position == pointB)
                {
                    towardsB = false; // Stops moving towards B
                    towardsA = true; // Starts moving towards A
                }
            }
            else if (towardsA) // Moving towards point A
            {
                transform.position = Vector3.MoveTowards(transform.position, pointA, speed * Time.deltaTime);

                if (transform.position == pointA)
                {
                    towardsA = false; // Stops moving towards A 
                    backwards = false;
                    inMovement = false;
                }
            }
        }

        if (transform.position == pointF && !plyerOnTop)
        {
            timePassed += Time.deltaTime; // Calculates the time
            if (timePassed > resetTime) 
            {
                backwards = true;
                towardsE = true;
                timePassed = 0f;
            }
        }
    }

    // Executed when a collision occurs
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Check that the collided object has the "Player" label
        {
            plyerOnTop = true;
            collision.transform.SetParent(transform); // Makes the object labeled "Player" a child of the platform, causing it to move along with it

            if (!inMovement)
            {
                if (transform.position == pointA)
                {
                    frontwards = true;
                    towardsB = true;
                    inMovement = true;
                }
                else if (transform.position == pointF)
                {
                    backwards = true;
                    towardsE = true;
                    inMovement = true;
                }
            }
            
            
        }
    }

    // Executed when a collision ends
    private void OnCollisionExit(Collision collision)
    { 
        if (collision.gameObject.CompareTag("Player")) // Check that the object that has stopped colliding has the "Player" tag
        {
            plyerOnTop = false;
            collision.transform.SetParent(null); // Removes the platform as the parent of the object labeled "Player"
        }
    }      
}