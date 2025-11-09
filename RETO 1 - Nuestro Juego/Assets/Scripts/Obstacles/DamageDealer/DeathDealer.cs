using UnityEngine;

public class DeathDealer : MonoBehaviour
{
    // Not visible variables
    private Player2D targetPlayer;
    private Rigidbody playerRB;

    // It runs once before the first Update it's executed
    void Start()
    {
   
    }

    // Update is executed once per frame
    void Update()
    {

    }

    // Executed when a collision occurs
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Check that the collided object has the "Player" label
        {
            targetPlayer = collision.transform.GetComponent<Player2D>();
            playerRB = targetPlayer.GetComponent<Rigidbody>();

            playerRB.linearVelocity = Vector3.zero; // Stop it from moving
            playerRB.angularVelocity = Vector3.zero; // Reset the physical rotation
            targetPlayer.transform.position = targetPlayer.GetRespawn(); // Respawn at the saved point
            targetPlayer.ApplyDamage(); // Deals damage
        }
    }
}