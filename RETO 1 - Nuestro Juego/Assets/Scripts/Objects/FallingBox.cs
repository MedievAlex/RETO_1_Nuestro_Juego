using UnityEngine;
using UnityEngine.Audio;

public class FallingBox : MonoBehaviour
{
    // Visible variables
    [Header("Manager")] // Makes a header on the public variables
    public GameManager gameManager;    

    // It runs once before the first Update it's executed
    void Start()
    {
        Debug.Log("[FallingBox] Searching for GameManager.");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // Finds the AudioController of the Scene
    }

    // Executed when a collision occurs
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player")) // Check that the collided object has the "Ground" or "Player" label
        {               
            gameManager.FallBoxAudio(GetComponent<AudioSource>());       
        }
    }
}