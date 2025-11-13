using UnityEngine;

public class Clouds : MonoBehaviour
{
    // Visible variables
    [Header("Positions")] // Makes a header on the public variables
    public Vector3 pointA; // First position
    public Vector3 pointB; // Second position
    public Vector3 pointC; // Third position
    public Vector3 pointD; // Fourth position
    public float speed = 2f; // Movement speed

    // Not visible variables
    private AudioSource audioSource;
    private bool towardsA = true; // Moving towards the first position (point A)
    private bool towardsB = false; // Moving towards the second position (point B)
    private bool towardsC = false; // Moving towards the third position (point C)
    private bool towardsD = false; // Moving towards the fourth position (point D)

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
}