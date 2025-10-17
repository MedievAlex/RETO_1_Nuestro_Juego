using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    // Not visible variables
    private PlayerControl2D targetPlayer;

    // It runs once before the first Update it's executed
    void Start()
    {
        targetPlayer = GameObject.Find("Player2D").GetComponent<PlayerControl2D>(); // Finds the GameObject of the class PlayerControl2D
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
            targetPlayer.applyDamage(); // Deals damage
            targetPlayer.getRigidbody().linearVelocity = Vector3.zero; // Stop it from moving
            targetPlayer.getRigidbody().angularVelocity = Vector3.zero; // Reset the physical rotation
            targetPlayer.transform.position = targetPlayer.getRespawn(); // Respawn at the saved point
        }
    }
}