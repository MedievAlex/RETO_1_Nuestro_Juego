using UnityEngine;

public class LeverGestion : MonoBehaviour
{
    // Not visible variables
    private Lever lever1; // If the ladder is actibable or not
    private Lever lever2; // If the ladder is actibable or not

    // START runs once before the first Update it's executed
    void Start()
    {

    }

    // UPDATE is executed once per frame
    void Update()
    {
       if(this.transform.GetChild(0).GetComponent<bool>())
       {
              
       }
       else if(this.transform.GetChild(0).GetComponent<bool>())
       {
           
       }
    }
}
