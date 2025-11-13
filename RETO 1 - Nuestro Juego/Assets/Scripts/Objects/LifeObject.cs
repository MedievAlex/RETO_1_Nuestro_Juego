using UnityEngine;

public class LifeObject : MonoBehaviour
{
    // Visible variables
    [Header("Manager")] // Makes a header on the public variables
    public GameManager gameManager;    

    // It runs once before the first Update it's executed
    void Start()
    {
        Debug.Log("[LifeObject] Searching for GameManager.");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // Finds the AudioController of the Scene
    }

    // Executed when a collision with a trigger happens
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player")) // Check that the object that has stopped colliding has the "Player" tag
        {
            Debug.Log("[LifeObject] +1 lives.");
            gameManager.LifeObjectAudio();
            gameManager.AbilityGestion("AddLife", true);
            Destroy(gameObject);
        }
    }
}
