using UnityEngine;

public class Lever : MonoBehaviour
{
    // Visible variables
    public bool stateActive; // If the ladder is active or not

    // Not visible variables
    private bool stateActivable; // If the ladder is active or not
    
    // START runs once before the first Update it's executed
    void Start()
    {
        
    }

    // UPDATE is executed once per frame
    void Update()
    {
       if (stateActivable && Input.GetKey(KeyCode.E)) // If the lever is activated, it desactivates it
       {
           if (stateActive) // If the lever is activated, it desactivates it
           {
                stateActive = false;
           } 
           else
           {
               stateActive = true;
           }
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
}
