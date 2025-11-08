using UnityEngine;

public class FallingStonesSpawn : MonoBehaviour
{
    // Visible variables 
    public FallingStone fallingStone;
    public StonesLever stonesController;
    public float spawnTime = 2f;

    // Not visible variables
    private AudioController audioController;    
    private float timePassed;
    private Vector3 spawnPoint;

    // It runs once before the first Update it's executed
    void Start()
    { 
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>(); // Finds the AudioController of the Scene
        spawnPoint = transform.position;
    }

    // Update is executed once per frame
    void Update()
    {
        if(stonesController.getFall()) 
        {
            timePassed += Time.deltaTime; // Calculates the time
            if (timePassed > spawnTime) // Creates a new object and restarts the counter
            {
                SpawnStone();
                timePassed = 0f;
            }
        }
    }

    // Generates more stones
    private void SpawnStone() // Spawns the object in the spawnpoint
    {
        audioController.RockBreakAudio(GetComponent<AudioSource>());    
        Instantiate(fallingStone, spawnPoint, Quaternion.identity, this.transform); 
    } 
}