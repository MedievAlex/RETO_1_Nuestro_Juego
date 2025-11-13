using UnityEngine;

public class FallingStonesSpawn : MonoBehaviour
{
    // Visible variables
    [Header("Manager")] // Makes a header on the public variables
    public GameManager gameManager;

    [Header("Atributes")] // Makes a header on the public variables
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
        Debug.Log("[FallingStonesSpawn] Searching for GameManager.");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // Finds the GameManager of the Scene
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
        gameManager.RockBreakAudio(GetComponent<AudioSource>());    
        Instantiate(fallingStone, spawnPoint, Quaternion.identity, this.transform); 
    } 
}