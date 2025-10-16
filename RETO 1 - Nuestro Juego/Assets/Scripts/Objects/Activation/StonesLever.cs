using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class StonesLever : MonoBehaviour
{
    // Visible variables
    public bool stateActive; // If the lever is active or not
    public float stopTime;

    // Not visible variables  
    private bool stateActivable; // If the ladder is actibable or not
    private bool fall; // Remaining extra attempts
    private float timePassed;

    // START runs once before the first Update it's executed
    void Start()
    {
        
    }

    // UPDATE is executed once per frame
    void Update()
    {
        if (stateActivable && Input.GetKeyDown(KeyCode.E)) // Changes lever's state
       {
           if (!stateActive) // If the lever was activated, it deactivates it
           {
                stateActive = true; 
           } 
           else // If the lever was deactivated, it activates it
           {
                stateActive = false;
           }
       }

       if (!stateActive) // If the lever was activated, it deactivates it
       {
            fall = true; 
       } 
       else // If the lever was deactivated, it activates it
       {
            fall = true;
       }

       timePassed += Time.deltaTime; // Calculates the time
       if (timePassed > stopTime) // Creates a new object and restarts the counter
       {
            stateActive = false;
            timePassed = 0f;
       }
    }

    // Executed when a collision with a trigger occurs
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player")) // Check that the collided object has the "Player" label
        {
            stateActivable = true;
        }
    }

    // Executed when a collision with a trigger ends
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player")) // Check that the collided object has the "Player" label
        {
            stateActivable = false;
        }
    }

    // Gets the value if it can fall or not
    public bool getFall()
    {
        return fall;
    }
}           