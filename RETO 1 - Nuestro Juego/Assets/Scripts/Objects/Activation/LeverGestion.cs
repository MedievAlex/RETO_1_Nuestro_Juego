using UnityEngine;

public class LeverGestion : MonoBehaviour
{
    // Visible variables

    // Not visible variables
    
    // START runs once before the first Update it's executed
    void Start()
    {
        
    }

    // UPDATE is executed once per frame
    void Update()
    {
       if(transform.GetChild(0).GetComponent<Lever>().stateActive)
       {
           transform.GetChild(1).GetComponent<Lever>().stateActive = false;
       }
       else if(transform.GetChild(1).GetComponent<Lever>().stateActive)
       {
           transform.GetChild(0).GetComponent<Lever>().stateActive = false;
       }
    }
}
