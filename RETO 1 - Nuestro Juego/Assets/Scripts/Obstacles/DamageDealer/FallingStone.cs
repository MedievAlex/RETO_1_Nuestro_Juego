using UnityEngine;

public class FallingStone : MonoBehaviour
{
    // Not visible variables
    private bool broken = false; // Indicates whether the object has touched the ground  

    // Update is executed once per frame
    void Update()
    {
        if (broken) // When it touches the ground
        {
            Destroy(gameObject); // It's destoyed
        }
    }

    // Executed when a collision occurs
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player")) // Check that the collided object has the "Ground" or "Player" label
        {
            broken = true;
        }
    }
}