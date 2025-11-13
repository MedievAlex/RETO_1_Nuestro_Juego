using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    // Visible variables
    [Header("Manager")] // Makes a header on the public variables
    public GameManager gameManager;  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("[MovingPlatforms] Searching for GameManager.");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // Finds the GameManager of the Scene
    }

    // Update is called once per frame
    void Update()
    {
        gameManager.MovingPlatformAudio(GetComponent<AudioSource>(), true);
    }
}
