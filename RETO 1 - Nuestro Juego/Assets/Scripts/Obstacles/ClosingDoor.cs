using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ClosingDoor : MonoBehaviour
{
    // Visible variables
    public Vector3 location; // Where it will fall

    // Not visible variables  
    private bool open;
    private float speed = 8f; // Fall speed

    // It runs once before the first Update it's executed
    void Start()
    {
        
    }

    // Update is executed once per frame
    void Update()
    {
        if (open)
        {
            transform.parent.position = Vector3.MoveTowards(transform.parent.position, location, speed * Time.deltaTime);

            if (transform.parent.position == location) 
            {
                open = false;
            }
        }
    }

    // Executed when a collision occurs
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player")) // Check that the collided object has the "Player" label
        {
            open = true;
        }  
    }
}