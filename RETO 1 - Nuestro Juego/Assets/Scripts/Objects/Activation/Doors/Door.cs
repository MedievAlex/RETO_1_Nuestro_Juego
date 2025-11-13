using UnityEngine;

public class Door : MonoBehaviour
{
    // Visible variables
    [Header("Manager")] // Makes a header on the public variables
    public GameManager gameManager;

    [Header("Locations")] // Makes a header on the public variables
    public Vector3 openLocation; 
    public Vector3 closeLocation;

    [Header("Star State")] // Makes a header on the public variables
    public bool startStateOpen; // If it starts open or closed

    // Not visible variables  
    private bool open, close;
    private bool opened, closed;
    private float speed = 8f; // Fall speed

    // It runs once before the first Update it's executed
    void Start()
    {
       Debug.Log("[Door] Searching for GameManager.");
       gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // Gets the Game Manager

       StartPositionOpen(startStateOpen);      
    }

    // Update is executed once per frame
    void Update()
    {
        if (open)
        {
            transform.position = Vector3.MoveTowards(transform.position, openLocation, speed * Time.deltaTime);

            if (transform.parent.position == openLocation) 
            {
                Debug.Log("[Door] Open.");
                open = false;
                opened = true;
            }
        }
        else if (close)
        {
            transform.position = Vector3.MoveTowards(transform.position, closeLocation, speed * Time.deltaTime);

            if (transform.parent.position == closeLocation) 
            {
                Debug.Log("[Door] Open.");
                close = false;
                closed = true;
            }
        }
    }

    // Start position
    public void StartPositionOpen(bool startOpen){
        Debug.Log("[Door] Start Open " + startOpen + ".");

       if (startOpen){
            transform.position = openLocation;
            opened = true;
       }
       else
       {
            transform.position = closeLocation;
            closed = true;
       }
    }

    // To change from open to close or reverse
    public void changeState()
    {
        if (opened || open)
        {
            gameManager.ClosingDoorAudio(GetComponent<AudioSource>());
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