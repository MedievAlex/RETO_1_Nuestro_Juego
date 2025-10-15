using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    // Visible variables
    public PlayerControl2D targetPlayer;
    private Vector3 spawnPoint;

    // It runs once before the first Update it's executed
    void Start()
    {
          
    }

    // Update is executed once per frame
    void Update()
    {
        
    }

    // Executed when a collision with a trigger occurs
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player")) // Check that the collided object has the "Player" label
        {
            targetPlayer.setRespawn(spawnPoint);
            Destroy(transform.GetChild(0).GetComponent<Collider>()); // Destroys the checkpoint
        }
    }
}