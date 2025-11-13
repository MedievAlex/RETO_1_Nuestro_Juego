using UnityEngine;

public class DoorPressurePlate : MonoBehaviour
{
    // Visible variables
    public Door door; // Referenced door

    // Executed when a collision occurs
    private void OnCollisionEnter(Collision collision)
    {
        door.changeState();
    }

    // Executed when a collision ends
    private void OnCollisionExit(Collision collision)
    {
        door.changeState();
    }
}