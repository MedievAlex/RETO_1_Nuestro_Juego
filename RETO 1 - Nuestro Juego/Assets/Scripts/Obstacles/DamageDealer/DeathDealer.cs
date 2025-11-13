using UnityEngine;

public class DeathDealer : MonoBehaviour
{
    // Visible variables
    [Header("Manager")] // Makes a header on the public variables
    public GameManager gameManager;

    // It runs once before the first Update it's executed
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // Finds the GameManager of the Scene
    }

    // Executed when a collision occurs
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Check that the collided object has the "Player" label
        {
            Debug.Log("[DeathDealer] Player Death.");
            gameManager.ApplyDamage();
            gameManager.Respawn();
        }
    }
}