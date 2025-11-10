using UnityEngine;
using UnityEngine.Audio;

public class ElevatorLever : MonoBehaviour
{
    // Visible variables
    public ElevatorControl elevator; // Referenced elevator
    public Vector3 destinationPosition; // Called destination

    // Not visible variables
    private Lever lever; 

    // START runs once before the first Update it's executed
    void Start()
    {
        lever = transform.GetComponent<Lever>();
        elevator.moveOnCall(destinationPosition, lever.GetState());    
    }

    // UPDATE is executed once per frame
    void Update()
    {
        if (lever.GetState()) // If the lever was deactivated, it activates it
        { 
            Debug.Log("[ElevatorLever] Elevator Activated.");
            elevator.moveOnCall(destinationPosition, lever.GetState());
        }

        if (elevator.transform.position == destinationPosition)  // When the elevator finishes moving it goes back to desactivated mode
        {   
            lever.SetState(false);
        }
    }
}
