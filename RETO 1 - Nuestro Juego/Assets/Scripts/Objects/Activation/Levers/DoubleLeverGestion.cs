using UnityEngine;

public class LeverGestion : MonoBehaviour
{
    // Visible variables
    public Lever lever1; // Referenced lever
    public Lever lever2; // Referenced lever

    // Update is called once per frame
    void Update()
    {
       if(lever1.GetActivable() && lever1.GetState())
       {
            lever2.SetState(false);
       }
       else if(lever2.GetActivable() && lever2.GetState())
       {
            lever1.SetState(false);
        }
    }
}
