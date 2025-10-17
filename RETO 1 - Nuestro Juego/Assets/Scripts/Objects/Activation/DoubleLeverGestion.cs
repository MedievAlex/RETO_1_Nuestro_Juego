using UnityEngine;

public class LeverGestion : MonoBehaviour
{
    // Visible variables
    public ElevatorCallLever lever1; // Referenced lever
    public ElevatorCallLever lever2; // Referenced lever

    // START runs once before the first Update it's executed
    void Start()
    {

    }

    // UPDATE is executed once per frame
    void Update()
    {
       if(lever1.getStateActivable() && lever1.stateActive)
       {
            lever2.stateActive = false;
       }
       else if(lever2.getStateActivable() && lever2.stateActive)
       {
            lever1.stateActive = false;
        }
    }
}
