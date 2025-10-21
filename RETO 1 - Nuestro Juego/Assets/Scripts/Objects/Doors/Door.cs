using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Visible variables
    public Vector3 openLocation; 
    public Vector3 closeLocation;
    public bool startStateOpen; // If it starts open or closed

    // Not visible variables  
    private bool open, close;
    private bool opened, closed;
    private float speed = 8f; // Fall speed

    // It runs once before the first Update it's executed
    void Start()
    {
        if (startStateOpen){
            transform.position = openLocation;
            opened = true;
        }
        else
        {
            transform.position = closeLocation;
            closed = true;
        }
    }

    // Update is executed once per frame
    void Update()
    {
        if (open)
        {
            transform.position = Vector3.MoveTowards(transform.position, openLocation, speed * Time.deltaTime);

            if (transform.parent.position == openLocation) 
            {
                open = false;
                opened = true;
            }
        }
        else if (close)
        {
            transform.position = Vector3.MoveTowards(transform.position, closeLocation, speed * Time.deltaTime);

            if (transform.parent.position == closeLocation) 
            {
                close = false;
                closed = true;
            }
        }
    }

    // To change from open to close or reverse
    public void changeState()
    {
        if (opened || open)
        {
            open = false;
            close = true;
        }
        else if (closed || close)
        {
            close = false;
            open = true;
        }
    }
}