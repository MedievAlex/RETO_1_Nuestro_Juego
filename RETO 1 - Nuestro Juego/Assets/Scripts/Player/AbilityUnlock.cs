using UnityEngine;

public class AbilityUnlock : MonoBehaviour
{
    // Visible variables
    public GameObject tutorial;
    public string abilityName;
    public bool activates;

    // Not visible variables
    private PlayerControl2D targetPlayer;

    // START runs once before the first UPDATE it's executed
    void Start()
    {
        targetPlayer = GameObject.Find("Player2D").GetComponent<PlayerControl2D>(); // Finds the GameObject of the class PlayerControl2D
        tutorialGestion(false);
    }

    // UPDATE is executed once per frame
    void Update()
    {
        
    }

    // Executed when a collision with a trigger occurs
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player")) // Check that the collided object has the "Player" label
        {
            tutorialGestion(true);
            targetPlayer.abilityGestion(abilityName, activates);
            Destroy(gameObject); // It's destoyed
        }
    }

    private void tutorialGestion(bool active)
    {
        if (tutorial != null)
        {
            tutorial.SetActive(active);
        }
    }
}
