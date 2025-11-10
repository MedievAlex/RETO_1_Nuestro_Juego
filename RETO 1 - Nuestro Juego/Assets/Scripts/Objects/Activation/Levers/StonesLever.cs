using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class StonesLever : MonoBehaviour
{
    // Visible variables
    public bool stateActive; // If the lever is active or not
    public float stopTime;

    // Not visible variables  
    private Lever lever; 
    private bool fall; // Remaining extra attempts
    private float timePassed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lever = transform.GetComponent<Lever>();
    }

    // UPDATE is executed once per frame
    void Update()
    {
        if (lever.GetState()) // If the lever was activated, it deactivates it
        { 
            fall = false;
            Debug.Log("[StonesLever] Stones falling " + fall + ".");
            
            timePassed += Time.deltaTime; // Calculates the time
            if (timePassed > stopTime) // Creates a new object and restarts the counter
            {
                lever.SetState(false);
                timePassed = 0f;
            }
        } 
        else // If the lever was deactivated, it activates it
        {
            fall = true;
            Debug.Log("[StonesLever] Stones falling " + fall + ".");
        }
    }

    // Gets the value if it can fall or not
    public bool getFall()
    {
        return fall;
    }
}           