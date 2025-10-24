using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Audio;

public class Door : MonoBehaviour
{
    // Visible variables
    public Vector3 openLocation; 
    public Vector3 closeLocation;
    public bool startStateOpen; // If it starts open or closed
    public AudioClip audioClip;

    // Not visible variables  
    private bool open, close;
    private bool opened, closed;
    private float speed = 8f; // Fall speed
    private AudioController audioController;

    // It runs once before the first Update it's executed
    void Start()
    {
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>(); // Finds the AudioController of the Scene

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
            audioController.oneShotAudio(audioClip, 1f, true);
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