using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Visible variables
    [Header("Manager")] // Makes a header on the public variables
    public GameManager gameManager;    

    // It runs once before the first Update it's executed
    void Start()
    {
        Debug.Log("[Checkpoint] Searching for GameManager.");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // Finds the AudioController of the Scene
    }

    // Executed when a collision with a trigger occurs
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player")) // Check that the collided object has the "Player" label
        {
            Debug.Log("[Checkpoint] Player arrived at a Checkpoint.");
            gameManager.CheckPointAudio(GetComponent<AudioSource>());
            gameManager.SetRespawn(collider.transform.position);
            Destroy(GetComponent<Collider>()); // Destroys the checkpoint
        }
    }
}