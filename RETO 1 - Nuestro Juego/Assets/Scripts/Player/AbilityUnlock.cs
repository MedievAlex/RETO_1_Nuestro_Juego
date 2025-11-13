using UnityEngine;

public class EndingCredits : MonoBehaviour
{
    // Visible variables
    [Header("Manager")] // Makes a header on the public variables
    public GameManager gameManager;    

    public GameObject tutorial;
    public string abilityName;
    public bool activates;

    // It runs once before the first Update it's executed
    void Start()
    {
        Debug.Log("[AbilityUnlock] Searching for GameManager.");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // Finds the AudioController of the Scene

        tutorialGestion(false);
    }

    // Executed when a collision with a trigger occurs
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player")) // Check that the collided object has the "Player" label
        {
            Debug.Log("[AbilityUnlock] " + abilityName + activates);
            tutorialGestion(true);
            gameManager.AbilityGestion(abilityName, activates);
            Destroy(gameObject); // It's destoyed
        }
    }

    // Shows the tutorial
    private void tutorialGestion(bool active)
    {
        if (tutorial != null)
        {
            Debug.Log("[AbilityUnlock] Tutorial Active " + active);
            tutorial.SetActive(active);
        }
    }
}
