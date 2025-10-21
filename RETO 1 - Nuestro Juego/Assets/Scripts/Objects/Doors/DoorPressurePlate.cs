using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DoorPressurePlate : MonoBehaviour
{
    // Visible variables
    public Door door; // Referenced door

    // It runs once before the first Update it's executed
    void Start()
    {
        
    }

    // Update is executed once per frame
    void Update()
    {
        
    }

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