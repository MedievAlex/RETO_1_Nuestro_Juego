using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    // Not visible variables
    private PlayerControl2D targetPlayer;
    private Rigidbody playerRB;

    // It runs once before the first Update it's executed
    void Start()
    {
        targetPlayer = GameObject.Find("Player2D").GetComponent<PlayerControl2D>(); // Finds the GameObject of the class PlayerControl2D
        playerRB = targetPlayer.GetComponent<Rigidbody>();
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
            if(!targetPlayer.isFrozen)
            {
                targetPlayer.isFrozen = true;
                targetPlayer.applyDamage(); // Deals damage
            }
        }
    }
}