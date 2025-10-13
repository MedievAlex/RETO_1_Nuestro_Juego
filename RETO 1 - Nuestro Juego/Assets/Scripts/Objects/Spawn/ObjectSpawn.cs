using UnityEngine;

/** [ STONE OBJECT FALLS AND DISAPPEARS ]
- Spawns and it falls. Once touching the floor dissapears.
*/
public class ObjectSpawn : MonoBehaviour
{
    public GameObject spawnedGameObject;
    public float spawnTime = 2f;
    private float timePassed;
    private Vector3 spawnPoint;

    // It runs once before the first Update it's executed
    void Start()
    {
        spawnPoint = transform.position;  
    }

    // Update is executed once per frame
    void Update()
    {
        timePassed += Time.deltaTime; // Calculates the time
        if (timePassed > spawnTime) // Creates a new object and restarts the counter
        {
            SpawnStone();
            timePassed = 0f;
        }
    }

    // Generates more stones
    private void SpawnStone() // Spawns the object in the spawnpoint
    {
        Instantiate(spawnedGameObject, spawnPoint, Quaternion.identity);
    }
}