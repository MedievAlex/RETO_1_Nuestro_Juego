using UnityEngine;

public class AbilityUnlock : MonoBehaviour
{
    // Visible variables
    public GameObject tutorial;
    public string abilityName;
    public bool activates;

    // START runs once before the first UPDATE it's executed
    void Start()
    {
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
            collider.GetComponent<PlayerControl2D>().AbilityGestion(abilityName, activates);
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
