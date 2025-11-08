using UnityEngine;

public class LifeObject : MonoBehaviour
{
    // Not visible variables  
    private Player2D targetPlayer; 
    private AudioController audioController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPlayer = GameObject.Find("Player2D").GetComponent<Player2D>(); // Finds the GameObject of the class PlayerControl2D
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>(); // Finds the AudioController of the Scene
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Executed when a collision with a trigger happens
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player")) // Check that the object that has stopped colliding has the "Player" tag
        {
            audioController.LifeObjectAudio();
            targetPlayer.AbilityGestion("AddLife", true);
            Destroy(gameObject);
        }
    }
}
