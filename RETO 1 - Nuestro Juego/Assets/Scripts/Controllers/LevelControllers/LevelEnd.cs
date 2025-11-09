using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    // Visible variables
    [Header("Manager")] // Makes a header on the public variables
    public GameManager gameManager;
    
    // START runs once before the first Update it's executed
    void Start()
    {
        Debug.Log("[LevelEnd] Searching for GameManager.");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // Finds the AudioController of the Scene
    }

    // UPDATE is executed once per frame
    void Update()
    {
        
    }

    // Executed when a collision with a trigger occurs
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player") && collider.transform.parent != null)
        {
            if (collider.gameObject.transform.parent.gameObject.CompareTag("Elevator")) // Check that the collided object has the "Player" label and its in the "Elevator"
            {
                Debug.Log("[LevelEnd] Player to Next Level.");
                collider.gameObject.GetComponent<Rigidbody>().linearVelocity = Vector3.zero; // Stop it from moving
                collider.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero; // Reset the physical rotation

                gameManager.NextLevel();
            }
        }
    }
}