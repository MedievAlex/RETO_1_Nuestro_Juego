using UnityEngine;

public class BreakablePlatformAtWeight : MonoBehaviour
{
    // Visible variables
    public float breakingTime = 2f; // In how many seconds it will break

    // Not visible variables  
    private float speed = 6f; // Fall speed
    private Vector3 location; // Where it will fall
    private bool hasWeight = false; // If the platform has weight
    private float timePassed;
    private bool breakPlatform = false; // If the platform brokes

    // It runs once before the first Update it's executed
    void Start()
    {
        location = transform.position; // Guardamos la posición inicial
        location.y = location.y - 6;
    }

    // Update is executed once per frame
    void Update()
    {
        if (hasWeight)
        {
            timePassed += Time.deltaTime; // Calculates the time
            if (timePassed > breakingTime) // Destroys the platform
            {
                breakPlatform = true;
            }  
        }

        if(breakPlatform)
        {
            transform.position = Vector3.MoveTowards(transform.position, location, speed * Time.deltaTime);
            if (transform.position == location)
            {
                Destroy(gameObject); // El objeto se destruirá en 2 frames (segundos)
            }
        }
    }

    // Executed when a collision occurs
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Check that the collided object has the "Player" label
        {
            hasWeight = true;
        }  
    }

    // Executed when a collision ends
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Check that the collided object has the "Player" label
        {
            hasWeight = false;
            timePassed = 0f;
        }
    }
}