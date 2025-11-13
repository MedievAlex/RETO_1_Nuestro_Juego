using UnityEngine;

public class DoorSensor : MonoBehaviour
{
    // Not visible variables
    private Door door; // Referenced door

    // It runs once before the first Update it's executed
    void Start()
    {
        door = transform.parent.gameObject.GetComponent<Door>();
    }

    // Executed when a collision occurs
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player")) // Check that the collided object has the "Player" label
        {
            door.changeState(); // Changes the doors state
        }  
    }
}